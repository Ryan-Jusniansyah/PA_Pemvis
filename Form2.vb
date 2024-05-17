Imports MySql.Data.MySqlClient

Public Class Form2

    Sub Kosong()
        txtSearch.Clear()
        txtSearch.Focus()
    End Sub

    Sub aturGrid()
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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Close()
    End Sub

    Sub tampilrak()
        DA = New MySqlDataAdapter("SELECT Id_sepatu, Nama_sepatu, Harga, Rilis, Jenis, Merek FROM tbrak", CONN)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "tbrak")
        DataGridView1.DataSource = DS.Tables("tbrak")
        DataGridView1.Refresh()
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        tampilrak()
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

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim hapus As String = "delete from tbrak where Id_Sepatu = '" & DataGridView1.Item(0, DataGridView1.CurrentRow.Index).Value & "'"
        CMD = New MySqlCommand(hapus, CONN)
        CMD.ExecuteNonQuery()
        MsgBox("Data berhasil dihapus")
        tampilrak()
        Kosong()
    End Sub
End Class