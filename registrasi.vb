Imports MySql.Data.MySqlClient

Public Class registrasi

    Sub Kosong()
        Nama.Clear()
        Email.Clear()
        txtNohp.Clear()
        Username.Clear()
        Password.Clear()
        Nama.Focus()
    End Sub

    Public Sub HanyaAngka(e As KeyPressEventArgs)
        Dim tombol As Integer = Asc(e.KeyChar)
        If Not (((tombol >= 48) And (tombol <= 57)) Or (tombol = 8)) Then
            e.Handled = True
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If nama.Text = Nothing Or email.Text = Nothing Or txtNohp.Text = Nothing Or username.Text = Nothing Or password.Text = Nothing Then
            MsgBox("Data Belum Lengkap")
            nama.Focus()
        Else
            CMD = New MySqlCommand("Select * from tbuser where Nama ='" & nama.Text & "'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()
            If Not RD.HasRows Then
                RD.Close()
                CMD = New MySqlCommand("insert into tbuser values('" & nama.Text & "', '" & email.Text & "', '" & txtNohp.Text & "', '" & username.Text & "','" & password.Text & "')", CONN)
                CMD.ExecuteNonQuery()
                Kosong()
                MsgBox("Anda Telah Berhasil Registrasi!")
                nama.Focus()
                Me.Close()
                Form_Login.Show()
            Else
                RD.Close()
                MsgBox("Data Tersebut Sudah Ada")
            End If
        End If
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Me.Close()
        Form_Login.Show()
    End Sub

    Private Sub registrasi_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub

    Private Sub txtNohp_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtNohp.KeyPress
        HanyaAngka(e)
    End Sub
End Class