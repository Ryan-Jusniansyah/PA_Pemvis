Imports MySql.Data.MySqlClient

Public Class Form_Login
    'Sub Admin()
    '    Form_Menu_Utama.AkunToolStripMenuItem.Visible = True
    '    Form_Menu_Utama.LoginToolStripMenuItem.Visible = False
    '    Form_Menu_Utama.Daftar.Visible = False
    '    Form_Menu_Utama.LogoutToolStripMenuItem.Visible = True
    '    Form_Menu_Utama.MenuToolStripMenuItem.Visible = True
    '    Form_Menu_Utama.PreOrderToolStripMenuItem.Visible = False
    '    Form_Menu_Utama.DataSepatuToolStripMenuItem.Visible = True
    '    Form_Menu_Utama.PemesananToolStripMenuItem.Visible = False
    '    Form_Menu_Utama.LaporanPreOrderToolStripMenuItem.Visible = True
    'End Sub
    '
    'Sub User()
    '    Form_Menu_Utama.AkunToolStripMenuItem.Visible = True
    '    Form_Menu_Utama.LoginToolStripMenuItem.Visible = False
    '    Form_Menu_Utama.Daftar.Visible = False
    '    Form_Menu_Utama.LogoutToolStripMenuItem.Visible = True
    '    Form_Menu_Utama.MenuToolStripMenuItem.Visible = True
    '    Form_Menu_Utama.PreOrderToolStripMenuItem.Visible = True
    '    Form_Menu_Utama.DataSepatuToolStripMenuItem.Visible = False
    '    Form_Menu_Utama.PemesananToolStripMenuItem.Visible = True
    '    Form_Menu_Utama.LaporanPreOrderToolStripMenuItem.Visible = False
    'End Sub

    Sub clear()
        txtUser.Clear()
        txtPass.Clear()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If (txtUser.Text = "ryan" And txtPass.Text = "Admin123") Or (txtUser.Text = "kayada" And txtPass.Text = "Admin123") Or (txtUser.Text = "hasbi" And txtPass.Text = "Admin123") Then
            LoginAdmin()
        Else
            CMD = New MySqlCommand("Select * from tbuser where Username = '" & txtUser.Text & "' and Password = '" & txtPass.Text & "'", CONN)
            RD = CMD.ExecuteReader
            If RD.HasRows Then
                RD.Close()
                MsgBox("Login Berhasil!")
                LoginUser()
            Else
                RD.Close()
                MsgBox("Username atau Password Salah")
            End If
        End If
    End Sub

    Sub LoginAdmin()
        Me.Close()
        MenuAdmin.Show()
        clear()
    End Sub

    Sub LoginUser()
        Me.Close()
        MenuUser.Show()
        clear()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        registrasi.Show()
        Me.Close()
    End Sub

    Private Sub Form_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
    End Sub
End Class