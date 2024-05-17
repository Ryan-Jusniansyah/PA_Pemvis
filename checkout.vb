Imports MySql.Data.MySqlClient
Public Class checkout

    Sub Kosong()
        txtNopel.Clear()
        txtkodesep.Clear()
        txtNamapel.Clear()
        txtAlamat.Clear()
        txtNohp.Clear()
        cbNamasep.Text = Nothing
        cbUkuran.Text = Nothing
        txtBayar.Clear()
        txtNopel.Focus()
    End Sub

    Sub aturgrid()
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 200
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(3).Width = 200
        DataGridView1.Columns(4).Width = 200
        DataGridView1.Columns(5).Width = 200
        DataGridView1.Columns(0).HeaderText = "Kode Jenis"
        DataGridView1.Columns(1).HeaderText = "Nama Jenis"
        DataGridView1.Columns(2).HeaderText = "Harga Sepatu"
        DataGridView1.Columns(3).HeaderText = "Rilis Sepatu"
        DataGridView1.Columns(4).HeaderText = "Jenis Sepatu"
        DataGridView1.Columns(5).HeaderText = "Merek Sepatu"
    End Sub

    Sub tampilrak()
        DA = New MySqlDataAdapter("SELECT Id_sepatu, Nama_sepatu, Harga, Rilis, Jenis, Merek FROM tbrak", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tbrak")
        DataGridView1.DataSource = DS.Tables("tbrak")
        DataGridView1.Refresh()
    End Sub

    Sub tampilSepatu()
        CMD = New MySqlCommand("select Nama_sepatu from tbrak", CONN)
        RD = CMD.ExecuteReader
        Do While RD.Read
            cbNamasep.Items.Add(RD.Item(0))
        Loop
        RD.Close()
    End Sub

    Public Sub HanyaAngka(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Chr(13) Then
            CMD = New MySqlCommand("Select * From tbrak where Id_sepatu like '%" & txtSearch.Text & "%'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()

            If RD.HasRows Then
                RD.Close()
                DA = New MySqlDataAdapter("Select * From tbrak where Id_sepatu like '%" & txtSearch.Text & "%'", CONN)
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

    Private Sub txtNohp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNohp.KeyPress
        HanyaAngka(e)
    End Sub

    Private Sub btnCheck_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        If txtNopel.Text = Nothing Then
            MsgBox("Data Belum Lengkap")
            txtNopel.Focus()
        Else
            CMD = New MySqlCommand("Select * from tbpemesanan where idpelanggan ='" & txtNopel.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                RD.Close()
                CMD = New MySqlCommand("insert into tbpemesanan values('" & txtNopel.Text & "', '" & txtkodesep.Text & "', '" & txtNamapel.Text & "', '" & cbNamasep.Text & "','" & txtAlamat.Text & "','" & txtNohp.Text & "', '" & cbUkuran.Text & "', '" & txtBayar.Text & "')", CONN)
                CMD.ExecuteNonQuery()
                Keranjang.tampilCheck()
                Kosong()
                MsgBox("Simpan Data Sukses!")
                txtNopel.Focus()
            Else
                RD.Close()
                MsgBox("Data Tersebut Sudah Ada")
            End If
        End If
    End Sub

    Private Sub txtBayar_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtBayar.KeyPress
        HanyaAngka(e)
    End Sub

    Private Sub txtNopel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNopel.KeyPress
        HanyaAngka(e)
    End Sub

    Private Sub txtkodesep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtkodesep.KeyPress
        HanyaAngka(e)
    End Sub

    Private Sub btnlihat_Click(sender As Object, e As EventArgs) Handles btnlihat.Click
        Me.Close()
        Keranjang.Show()
    End Sub

    Private Sub checkout_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tampilrak()
        aturgrid()
        tampilSepatu()
        Keranjang.tampilCheck()
        Kosong()
    End Sub

    Private Sub cbNamasep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbNamasep.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cbUkuran_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbUkuran.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Form3.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MenuUser.Show()
        Me.Hide()
    End Sub

    Public Sub HanyaHuruf(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 65) And (tombol <= 90)) Or ((tombol >= 97) And
       (tombol <= 122)) Or (tombol = 8) Or (tombol = 32) Or (tombol = 46)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNamapel_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNamapel.KeyPress
        HanyaHuruf(e)
    End Sub
End Class