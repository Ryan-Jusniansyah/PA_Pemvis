Public Class MenuAdmin

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click
        LaporanPo.Show()
        Me.Hide()
    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click
        Form_Menu_Utama.Show()
        Me.Hide()
    End Sub
End Class