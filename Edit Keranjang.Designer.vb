<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Edit_Keranjang
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.txtBayar = New System.Windows.Forms.TextBox()
        Me.txtnohp = New System.Windows.Forms.TextBox()
        Me.txtAlamat = New System.Windows.Forms.TextBox()
        Me.cbNamasep = New System.Windows.Forms.ComboBox()
        Me.txtNamapel = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSimpan = New System.Windows.Forms.Button()
        Me.txtkodesep = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtNopel = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbUkuran = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'txtBayar
        '
        Me.txtBayar.Location = New System.Drawing.Point(264, 393)
        Me.txtBayar.MaxLength = 13
        Me.txtBayar.Name = "txtBayar"
        Me.txtBayar.Size = New System.Drawing.Size(309, 22)
        Me.txtBayar.TabIndex = 31
        '
        'txtnohp
        '
        Me.txtnohp.Location = New System.Drawing.Point(264, 312)
        Me.txtnohp.MaxLength = 13
        Me.txtnohp.Name = "txtnohp"
        Me.txtnohp.Size = New System.Drawing.Size(309, 22)
        Me.txtnohp.TabIndex = 30
        '
        'txtAlamat
        '
        Me.txtAlamat.Location = New System.Drawing.Point(264, 266)
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(309, 22)
        Me.txtAlamat.TabIndex = 29
        '
        'cbNamasep
        '
        Me.cbNamasep.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbNamasep.FormattingEnabled = True
        Me.cbNamasep.Location = New System.Drawing.Point(264, 219)
        Me.cbNamasep.Name = "cbNamasep"
        Me.cbNamasep.Size = New System.Drawing.Size(309, 24)
        Me.cbNamasep.TabIndex = 28
        '
        'txtNamapel
        '
        Me.txtNamapel.Location = New System.Drawing.Point(264, 172)
        Me.txtNamapel.Name = "txtNamapel"
        Me.txtNamapel.Size = New System.Drawing.Size(309, 22)
        Me.txtNamapel.TabIndex = 27
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(107, 396)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(49, 17)
        Me.Label7.TabIndex = 25
        Me.Label7.Text = "Bayar:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(107, 315)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(52, 17)
        Me.Label6.TabIndex = 24
        Me.Label6.Text = "No.Hp:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(107, 269)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(55, 17)
        Me.Label5.TabIndex = 23
        Me.Label5.Text = "Alamat:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(107, 222)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(98, 17)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Nama Sepatu:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(107, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 17)
        Me.Label3.TabIndex = 21
        Me.Label3.Text = "Nama:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 16.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(281, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(205, 31)
        Me.Label2.TabIndex = 34
        Me.Label2.Text = "Edit Keranjang"
        '
        'btnSimpan
        '
        Me.btnSimpan.BackColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.btnSimpan.ForeColor = System.Drawing.Color.White
        Me.btnSimpan.Location = New System.Drawing.Point(287, 452)
        Me.btnSimpan.Name = "btnSimpan"
        Me.btnSimpan.Size = New System.Drawing.Size(188, 36)
        Me.btnSimpan.TabIndex = 35
        Me.btnSimpan.Text = "Simpan"
        Me.btnSimpan.UseVisualStyleBackColor = False
        '
        'txtkodesep
        '
        Me.txtkodesep.Location = New System.Drawing.Point(264, 127)
        Me.txtkodesep.MaxLength = 4
        Me.txtkodesep.Name = "txtkodesep"
        Me.txtkodesep.Size = New System.Drawing.Size(98, 22)
        Me.txtkodesep.TabIndex = 39
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(107, 130)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(94, 17)
        Me.Label9.TabIndex = 38
        Me.Label9.Text = "Kode Sepatu:"
        '
        'txtNopel
        '
        Me.txtNopel.Location = New System.Drawing.Point(264, 87)
        Me.txtNopel.MaxLength = 4
        Me.txtNopel.Name = "txtNopel"
        Me.txtNopel.Size = New System.Drawing.Size(98, 22)
        Me.txtNopel.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(107, 90)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 17)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "No.Pelanggan:"
        '
        'cbUkuran
        '
        Me.cbUkuran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbUkuran.FormattingEnabled = True
        Me.cbUkuran.Items.AddRange(New Object() {"37", "38", "39", "40", "41", "42", "43", "44", "45", "46", "47", "48"})
        Me.cbUkuran.Location = New System.Drawing.Point(264, 353)
        Me.cbUkuran.Name = "cbUkuran"
        Me.cbUkuran.Size = New System.Drawing.Size(126, 24)
        Me.cbUkuran.TabIndex = 41
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(107, 356)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(58, 17)
        Me.Label8.TabIndex = 40
        Me.Label8.Text = "Ukuran:"
        '
        'Edit_Keranjang
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(753, 500)
        Me.Controls.Add(Me.cbUkuran)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtkodesep)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtNopel)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnSimpan)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtBayar)
        Me.Controls.Add(Me.txtnohp)
        Me.Controls.Add(Me.txtAlamat)
        Me.Controls.Add(Me.cbNamasep)
        Me.Controls.Add(Me.txtNamapel)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Name = "Edit_Keranjang"
        Me.Text = "Edit_Keranjang"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBayar As System.Windows.Forms.TextBox
    Friend WithEvents txtnohp As System.Windows.Forms.TextBox
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents cbNamasep As System.Windows.Forms.ComboBox
    Friend WithEvents txtNamapel As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSimpan As System.Windows.Forms.Button
    Friend WithEvents txtkodesep As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtNopel As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cbUkuran As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
End Class
