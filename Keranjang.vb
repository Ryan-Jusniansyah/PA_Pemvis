Imports MySql.Data.MySqlClient
Imports System.Drawing.Printing

Public Class Keranjang
    Dim WithEvents PD As New PrintDocument
    Dim PPD As New PrintPreviewDialog
    Dim t_harga As Long
    Dim panjang As Integer

    Sub Kosong()
        txtSearch.Clear()
        txtSearch.Focus()
    End Sub

    Sub AturGrid()
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(3).Width = 200
        DataGridView1.Columns(4).Width = 200
        DataGridView1.Columns(5).Width = 200
        DataGridView1.Columns(6).Width = 60
        DataGridView1.Columns(7).Width = 200
        DataGridView1.Columns(0).HeaderText = "No"
        DataGridView1.Columns(1).HeaderText = "Kode Sepatu"
        DataGridView1.Columns(2).HeaderText = "Nama Pelanggan"
        DataGridView1.Columns(3).HeaderText = "Nama Sepatu"
        DataGridView1.Columns(4).HeaderText = "Alamat"
        DataGridView1.Columns(5).HeaderText = "No.Hp"
        DataGridView1.Columns(6).HeaderText = "Size"
        DataGridView1.Columns(7).HeaderText = "Harga"
    End Sub

    Sub tampilCheck()
        DA = New MySqlDataAdapter("SELECT idpelanggan ,Id_sepatu, Namapel, Namasep, alamatpel, nohp, size, harga FROM tbpemesanan", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tbpemesanan")
        DataGridView1.DataSource = DS.Tables("tbpemesanan")
        DataGridView1.Refresh()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim hapus As String = "DELETE FROM tbpemesanan where idpelanggan='" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "'"
        CMD = New MySqlCommand(hapus, CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Pesanan telah dihapus")
        tampilCheck()
    End Sub

    Private Sub btnBayar_Click(sender As Object, e As EventArgs) Handles btnBayar.Click
        ubahpanjang()

        PPD.Document = PD
        PPD.ShowDialog()

        CMD = New MySqlCommand("TRUNCATE TABLE tbpemesanan", CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Terima Kasih Sudah Order")
        tampilCheck()
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Chr(13) Then
            CMD = New MySqlCommand("Select * From tbpemesanan where Idpelanggan like '%" & txtSearch.Text & "%'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()

            If RD.HasRows Then
                RD.Close()
                DA = New MySqlDataAdapter("Select * From tbpemesanan where Idpelanggan like '%" & txtSearch.Text & "%'", CONN)
                DS = New DataSet
                DA.Fill(DS, "Dapat")
                DataGridView1.DataSource = DS.Tables("Dapat")
                DataGridView1.ReadOnly = True
            Else
                RD.Close()
                MsgBox("Data tidak ditemukan")
            End If
        End If
    End Sub

    Private Sub Keranjang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        AturGrid()
        tampilCheck()
        Kosong()
    End Sub

    Private Sub btnKembali_Click(sender As Object, e As EventArgs) Handles btnKembali.Click
        Me.Close()
        checkout.Show()
    End Sub

    Private Sub btnedit_Click(sender As Object, e As EventArgs) Handles btnedit.Click
        Edit_Keranjang.Show()
    End Sub

    Private Sub PD_BeginPrint(sender As Object, e As PrintEventArgs) Handles PD.BeginPrint
        Dim pagesetup As New PageSettings
        pagesetup.PaperSize = New PaperSize("Custom", 250, panjang)
        PD.DefaultPageSettings = pagesetup
    End Sub

    Private Sub PD_PrintPage(sender As Object, e As PrintPageEventArgs) Handles PD.PrintPage
        Dim f10 As New Font("Times New Roman", 10, FontStyle.Regular)
        Dim f10b As New Font("Times New Roman", 10, FontStyle.Bold)
        Dim f14b As New Font("Times New Roman", 14, FontStyle.Bold)

        Dim leftmargin As Integer = PD.DefaultPageSettings.Margins.Left
        Dim centermargin As Integer = PD.DefaultPageSettings.PaperSize.Width / 2
        Dim rightmargin As Integer = PD.DefaultPageSettings.PaperSize.Width

        Dim kanan As New StringFormat
        Dim tengah As New StringFormat
        kanan.Alignment = StringAlignment.Far
        tengah.Alignment = StringAlignment.Center

        Dim garis As String
        garis = "==========================================================="

        e.Graphics.DrawString("Sneaker Zone", f14b, Brushes.Black, centermargin, 5, tengah)
        e.Graphics.DrawString("Jl. Lambung No.55", f10, Brushes.Black, centermargin, 25, tengah)
        e.Graphics.DrawString("Hp. 081110968789", f10, Brushes.Black, centermargin, 40, tengah)

        e.Graphics.DrawString("No.Kasir", f10, Brushes.Black, 0, 60)
        e.Graphics.DrawString(":", f10, Brushes.Black, 65, 60)
        e.Graphics.DrawString("1", f10, Brushes.Black, 75, 60)

        e.Graphics.DrawString("Kasir", f10, Brushes.Black, 0, 75)
        e.Graphics.DrawString(":", f10, Brushes.Black, 65, 75)
        e.Graphics.DrawString("Kayada", f10, Brushes.Black, 75, 75)

        e.Graphics.DrawString(garis, f10, Brushes.Black, 0, 90)

        DataGridView1.AllowUserToAddRows = False

        Dim tinggi As Integer
        Dim i As Long
        For baris As Integer = 0 To DataGridView1.RowCount - 1
            tinggi += 15
            e.Graphics.DrawString(DataGridView1.Rows(baris).Cells(3).Value.ToString, f10, Brushes.Black, 0, 90 + tinggi)

            i = DataGridView1.Rows(baris).Cells(7).Value
            DataGridView1.Rows(baris).Cells(7).Value = Format(i, "##,##0")
            e.Graphics.DrawString(DataGridView1.Rows(baris).Cells(7).Value.ToString, f10, Brushes.Black, rightmargin, 90 + tinggi, kanan)

        Next
        tinggi = 100 + tinggi
        total()
        e.Graphics.DrawString(garis, f10, Brushes.Black, 0, tinggi)
        e.Graphics.DrawString("Total : " & Format(t_harga, "##,##0"), f10b, Brushes.Black, rightmargin, 10 + tinggi, kanan)

        e.Graphics.DrawString("~TerimaKasih Telah Belanja~", f10, Brushes.Black, centermargin, 35 + tinggi, tengah)
        e.Graphics.DrawString("~Di Sneaker Zone~", f10, Brushes.Black, centermargin, 50 + tinggi, tengah)
        e.Graphics.DrawString("Lakukan Transaksi Sesuai Nomor Diatas!", f10, Brushes.Black, centermargin, 65 + tinggi, tengah)
    End Sub

    Sub total()
        Dim hitung As Long = 0
        For baris As Long = 0 To DataGridView1.RowCount - 1
            hitung = hitung + DataGridView1.Rows(baris).Cells(7).Value
        Next
        t_harga = hitung
    End Sub

    Sub ubahpanjang()
        Dim rowcount As Integer
        panjang = 0

        rowcount = DataGridView1.Rows.Count
        panjang = rowcount * 15
        panjang = panjang + 200
    End Sub
End Class