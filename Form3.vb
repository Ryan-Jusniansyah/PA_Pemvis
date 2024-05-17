Imports MySql.Data.MySqlClient
Public Class Form3

    Sub kosong()
        txtAntrian.Clear()
        txtNama.Clear()
        txtNoHp.Clear()
        txtKodeSepatu.Clear()
        cbJenis.Text = Nothing
        cbMerek.Text = Nothing
        txtAntrian.Focus()
    End Sub

    Sub tampilPo()
        DA = New MySqlDataAdapter("SELECT Idantrian, Id_Sepatu,Namapel, nohp, Merek, Jenis FROM tbpo", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tbpo")
        DataGridView1.DataSource = DS.Tables("tbpo")
        DataGridView1.Refresh()
    End Sub

    Sub tampilMer()
        CMD = New MySqlCommand("select Merek from tbrak", CONN)
        RD = CMD.ExecuteReader
        Do While RD.Read
            cbMerek.Items.Add(RD.Item(0))
        Loop
        RD.Close()
    End Sub

    Sub tampilJen()
        CMD = New MySqlCommand("select Jenis from tbrak", CONN)
        RD = CMD.ExecuteReader
        Do While RD.Read
            cbJenis.Items.Add(RD.Item(0))
        Loop
        RD.Close()
    End Sub

    Sub AturGrid()
        DataGridView1.Columns(0).Width = 60
        DataGridView1.Columns(1).Width = 60
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(3).Width = 200
        DataGridView1.Columns(4).Width = 200
        DataGridView1.Columns(5).Width = 200
        DataGridView1.Columns(0).HeaderText = "Antrian"
        DataGridView1.Columns(1).HeaderText = "Kode Sepatu"
        DataGridView1.Columns(2).HeaderText = "Nama Pelanggan"
        DataGridView1.Columns(3).HeaderText = "No.Hp"
        DataGridView1.Columns(4).HeaderText = "Merek Sepatu"
        DataGridView1.Columns(5).HeaderText = "Jenis Sepatu"
    End Sub

    Public Sub HanyaAngka(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8)) Then
            e.Handled = True
        End If
    End Sub



    Private Sub btnTambah_Click(sender As Object, e As EventArgs) Handles btnTambah.Click
        CMD = New MySqlCommand("select * from tbpo where Idantrian = '" & txtAntrian.Text & "'", CONN)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            RD.Close()
            CMD = New MySqlCommand("insert into tbpo values ('" & txtAntrian.Text & "', '" & txtKodeSepatu.Text & "', '" & txtNama.Text & "', '" & txtNoHp.Text & "', '" & cbMerek.Text & "', '" & cbJenis.Text & "')", CONN)
            CMD.ExecuteNonQuery()
        End If
        RD.Close()
        kosong()
        tampilPo()

        txtAntrian.Focus()
    End Sub

    Private Sub btnUbah_Click(sender As Object, e As EventArgs) Handles btnUbah.Click
        If txtAntrian.Text = Nothing Then
            MsgBox("Antrian Belum diisi")
            txtAntrian.Focus()
        Else
            Dim ubah As String = "update tbpo set Idantrian = '" & txtAntrian.Text & "', Id_Sepatu = '" & txtKodeSepatu.Text & "', Namapel = '" & txtNama.Text & "', nohp = '" & txtNoHp.Text & "', Merek = '" & cbMerek.Text & "', Jenis = '" & cbJenis.Text & "' where Idantrian = '" & txtAntrian.Text & "'"
            CMD = New MySqlCommand(ubah, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil diubah")
            tampilPo()
            kosong()
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        kosong()
        tampilPo()
    End Sub

    Private Sub btnHapus_Click(sender As Object, e As EventArgs) Handles btnHapus.Click
        Dim hapus As String = "DELETE FROM tbpo where IdAntrian ='" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "'"
        CMD = New MySqlCommand(hapus, CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Pesanan telah dihapus")
        tampilPo()
        kosong()
    End Sub

    Private Sub txtNoHp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNoHp.KeyPress
        HanyaAngka(e)
    End Sub

    Private Sub Form3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tampilMer()
        tampilJen()
        tampilPo()
        AturGrid()
        kosong()
    End Sub

    Private Sub cbJenis_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbJenis.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cbMerek_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbMerek.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        checkout.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MenuUser.Show()
        Me.Hide()
    End Sub

    Private Sub txtAntrian_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtAntrian.KeyPress
        HanyaAngka(e)
    End Sub

    Private Sub txtKodeSepatu_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtKodeSepatu.KeyPress
        HanyaAngka(e)
    End Sub

    Public Sub HanyaHuruf(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 65) And (tombol <= 90)) Or ((tombol >= 97) And
       (tombol <= 122)) Or (tombol = 8) Or (tombol = 32) Or (tombol = 46)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtNama_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNama.KeyPress
        HanyaHuruf(e)
    End Sub
End Class