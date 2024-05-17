Imports MySql.Data.MySqlClient

Public Class LaporanPo

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

    Sub tampilPo()
        DA = New MySqlDataAdapter("SELECT Idantrian, Id_Sepatu,Namapel, nohp, Merek, Jenis FROM tbpo", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tbpo")
        DataGridView1.DataSource = DS.Tables("tbpo")
        DataGridView1.Refresh()
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If e.KeyChar = Chr(13) Then
            CMD = New MySqlCommand("Select * From tbpo where IdAntrian like '%" & txtSearch.Text & "%'", CONN)
            RD = CMD.ExecuteReader
            RD.Read()

            If RD.HasRows Then
                RD.Close()
                DA = New MySqlDataAdapter("Select * From tbpo where IdAntrian like '%" & txtSearch.Text & "%'", CONN)
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

    Private Sub btntutup_Click(sender As Object, e As EventArgs) Handles btntutup.Click
        Me.Hide()
        MenuAdmin.Show()
    End Sub

    Private Sub LaporanPo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tampilPo()
        AturGrid()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles Label9.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click
        Form_Menu_Utama.Show()
        Me.Hide()
    End Sub
End Class