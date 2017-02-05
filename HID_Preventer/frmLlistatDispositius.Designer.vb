<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLlistatDispositius
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.listDisp = New System.Windows.Forms.ListBox()
        Me.SuspendLayout()
        '
        'listDisp
        '
        Me.listDisp.FormattingEnabled = True
        Me.listDisp.Location = New System.Drawing.Point(57, 33)
        Me.listDisp.Name = "listDisp"
        Me.listDisp.Size = New System.Drawing.Size(563, 251)
        Me.listDisp.TabIndex = 0
        '
        'frmLlistatDispositius
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(692, 327)
        Me.Controls.Add(Me.listDisp)
        Me.Name = "frmLlistatDispositius"
        Me.Text = "Dispositius"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents listDisp As ListBox
End Class
