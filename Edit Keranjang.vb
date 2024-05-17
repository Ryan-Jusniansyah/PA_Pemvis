Imports MySql.Data.MySqlClient

Public Class Edit_Keranjang

    Sub Kosong()
        txtNopel.Clear()
        txtkodesep.Clear()
        txtNamapel.Clear()
        txtAlamat.Clear()
        txtnohp.Clear()
        cbNamasep.Text = Nothing
        txtBayar.Clear()
        txtNopel.Focus()
    End Sub
    Sub tampilSepatu()
        CMD = New MySqlCommand("select Nama_sepatu from tbrak", CONN)
        RD = CMD.ExecuteReader
        Do While RD.Read
            cbNamasep.Items.Add(RD.Item(0))
        Loop
        RD.Close()
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtNopel.Text = Nothing Then
            MsgBox("Nomor pelanggan belum diisi")
            txtNopel.Focus()
        Else
            Dim ubah As String = "update tbpemesanan set Id_Sepatu = '" & txtkodesep.Text & "', Namapel = '" & txtNamapel.Text & "', Namasep = '" & cbNamasep.Text & "', alamatpel = '" & txtAlamat.Text & "', nohp = '" & txtnohp.Text & "', size = '" & cbUkuran.Text & "', harga = '" & txtBayar.Text & "' where idpelanggan = '" & txtNopel.Text & "'"
            CMD = New MySqlCommand(ubah, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil diubah")
            Keranjang.tampilCheck()
            Kosong()
        End If
    End Sub

    Private Sub Edit_Keranjang_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tampilSepatu()
        Keranjang.tampilCheck()
        Kosong()
    End Sub

    Public Sub HanyaAngka(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub txtnohp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtnohp.KeyPress
        HanyaAngka(e)
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

    Private Sub cbNamasep_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbNamasep.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub cbUkuran_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbUkuran.KeyPress
        e.KeyChar = Chr(0)
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