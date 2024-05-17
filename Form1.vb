Imports MySql.Data.MySqlClient

Public Class Form1
    Dim jenis As String

    Sub Kosong()
        txtId.Focus()
        txtId.Clear()
        txtNama.Clear()
        txtHarga.Clear()
        cbMerek.Text = String.Empty
        rbBasket.Checked = False
        rbLari.Checked = False
        rbSneakers.Checked = False
    End Sub

    Private Sub btnSimpan_Click(sender As Object, e As EventArgs) Handles btnSimpan.Click
        If txtId.Text = Nothing Then
            MsgBox("Data Belum Lengkap")
            txtId.Focus()
        Else
            CMD = New MySqlCommand("Select * from tbrak where Id_sepatu ='" & txtId.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                cekRadio()
                RD.Close()
                CMD = New MySqlCommand("insert into tbrak values('" & txtId.Text & "', '" & txtNama.Text & "', '" & txtHarga.Text & "', '" & dtpRilis.Value.ToString("yyyy-MM-dd") & "','" & jenis & "','" & cbMerek.Text & "')", CONN)
                CMD.ExecuteNonQuery()
                Form2.tampilrak()
                Kosong()
                MsgBox("Simpan Data Sukses!")
                txtId.Focus()
            Else
                RD.Close()
                MsgBox("Data Tersebut Sudah Ada")
            End If
        End If
    End Sub

    Private Sub btnBatal_Click(sender As Object, e As EventArgs) Handles btnBatal.Click
        Kosong()
        Form2.tampilrak()
    End Sub

    Private Sub btnLihat_Click(sender As Object, e As EventArgs) Handles btnLihat.Click
        Form2.Show()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        Form2.tampilrak()
        Kosong()
    End Sub

    Sub cekRadio()
        For Each ctrl As Control In GroupBox1.Controls
            If TypeOf ctrl Is RadioButton Then
                If (DirectCast(ctrl, RadioButton).Checked) Then
                    jenis = DirectCast(ctrl, RadioButton).Text
                End If
            End If
        Next
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        If txtId.Text = Nothing Then
            MsgBox("Id Sepatu belum diisi")
            txtId.Focus()
        Else
            cekRadio()
            Dim ubah As String = "update tbrak set Nama_sepatu = '" & txtNama.Text & "', Harga = '" & txtHarga.Text & "', Rilis = '" & dtpRilis.Value.ToString("yyyy-MM-dd") & "', Jenis = '" & jenis & "', Merek = '" & cbMerek.Text & "' where Id_Sepatu = '" & txtId.Text & "'"
            CMD = New MySqlCommand(ubah, CONN)
            CMD.ExecuteNonQuery()
            MsgBox("Data berhasil diubah")
            Form2.tampilrak()
            Kosong()
        End If
    End Sub

    Private Sub cbMerek_KeyPress(sender As Object, e As KeyPressEventArgs) Handles cbMerek.KeyPress
        e.KeyChar = Chr(0)
    End Sub

    Private Sub txtHarga_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtHarga.KeyPress
        HanyaAngka(e)
    End Sub

    Public Sub HanyaAngka(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8)) Then
            e.Handled = True
        End If
    End Sub

    Public Sub HanyaHuruf(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 65) And (tombol <= 90)) Or ((tombol >= 97) And
       (tombol <= 122)) Or (tombol = 8) Or (tombol = 32) Or (tombol = 46)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs) Handles Label7.Click
        LaporanPo.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        MenuAdmin.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Form_Menu_Utama.Show()
        Me.Hide()
    End Sub

    Private Sub txtId_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtId.KeyPress
        HanyaAngka(e)
    End Sub
End Class
