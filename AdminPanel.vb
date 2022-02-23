Public Class AdminPanel
    Private Sub FOODToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FOODToolStripMenuItem.Click
        Dim ss As New FOOD
        ss.Show()
        Me.Hide()

    End Sub

    Private Sub USERToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles USERToolStripMenuItem.Click
        Dim ss As New USER
        ss.Show()
        Me.Hide()

    End Sub

    Private Sub LOGOUTToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LOGOUTToolStripMenuItem.Click
        Dim ss As New Form1
        ss.Show()
        Me.Hide()

    End Sub

    Private Sub AdminPanel_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class