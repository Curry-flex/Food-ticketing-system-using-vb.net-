Imports System.Data.SqlClient
Imports Microsoft.Reporting.WinForms



Public Class Myreport
    Dim con As New SqlConnection("Data Source=DESKTOP-GJACM0V\CURRYSQL;Initial Catalog=Food_ticketing_System;Integrated Security=True")
    Private Sub Myreport_Load(sender As Object, e As EventArgs) Handles MyBase.Load





    End Sub

    Private Sub ReportViewer1_Load(sender As Object, e As EventArgs) Handles ReportViewer1.Load

    End Sub
    Sub loadBiiling(ByVal sql As String)
        Try
            Dim rptds As ReportDataSource
            ReportViewer1.RefreshReport()
            With ReportViewer1.LocalReport
                .ReportPath = Application.StartupPath & "\Report\Report10.rdlc"
                .DataSources.Clear()

            End With

            Dim ds As New DataSet1

            Dim da As New SqlDataAdapter
            con.Open()
            da.SelectCommand = New SqlCommand(sql, con)
            da.Fill(ds.Tables("recipient"))
            rptds = New ReportDataSource("DataSet1", ds.Tables("recipient"))

            ReportViewer1.LocalReport.DataSources.Add(rptds)
            ReportViewer1.SetDisplayMode(Microsoft.Reporting.WinForms.DisplayMode.PrintLayout)
            ReportViewer1.ZoomMode = ZoomMode.Percent
            ReportViewer1.ZoomPercent = 100

            con.Close()




        Catch ex As Exception

            MsgBox(ex.Message, vbCritical)
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) 

    End Sub
End Class