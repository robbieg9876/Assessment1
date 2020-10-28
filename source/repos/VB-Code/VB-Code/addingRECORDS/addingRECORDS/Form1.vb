Public Class Form1
    Dim dbProvider As String
    Dim dbSource As String
    Dim dbp As String
    Dim dbs As String
    Dim dataSet As New DataSet
    Dim dataAdapter As OleDb.OleDbDataAdapter
    Dim ds As New DataSet
    Dim da As OleDb.OleDbDataAdapter
    Dim sql As String
    Dim x As Integer
    Dim y As Integer
    Dim con As New OleDb.OleDbConnection
    Dim clientname As String
    Dim filename As String
    Dim dates As String
    Dim prepare As Boolean
    Dim total As Decimal
    Dim total1 As Decimal
    Dim total2 As Decimal
    Dim total3 As Decimal
    Dim total4 As Decimal
    Dim total5 As Decimal
    Dim total6 As Decimal
    Dim total7 As Decimal
    Dim total8 As Decimal
    Dim total9 As Decimal
    Dim total10 As Decimal
    Dim total11 As Decimal
    Dim paytype As String
    Dim fixed As Boolean
    Private Sub btnOPEN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOPEN.Click
        y = InputBox("How many records?")
        y = y - 1
        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
        dbSource = "Data Source = C:\Users\robbi\dtbClients1.mdb"
        con.ConnectionString = dbProvider & dbSource
        con.Open()
        MsgBox("Database is now open")
        sql = "SELECT * FROM tblClients2"
        dataAdapter = New OleDb.OleDbDataAdapter(sql, con)
        dataAdapter.Fill(dataSet, "dtbClients1")
        x = 0
        txtFORENAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(1)
        txtSURNAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(2)
        txtDOB.Text = dataSet.Tables("dtbClients1").Rows(x).Item(3)
        txtADDRESS.Text = dataSet.Tables("dtbClients1").Rows(x).Item(4)
        txtPARENT.Text = dataSet.Tables("dtbClients1").Rows(x).Item(5)
        txtPHONE.Text = dataSet.Tables("dtbClients1").Rows(x).Item(6)
        txtEMAIL.Text = dataSet.Tables("dtbClients1").Rows(x).Item(7)
        prepare = True
    End Sub
    Private Sub btnCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLOSE.Click
        con.Close()
        MsgBox("Database is now Closed")
        txtFORENAME.Text = ""
        txtSURNAME.Text = ""
    End Sub




    Private Sub btnADDNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADDNEW.Click
        Dim commandBuilder As New OleDb.OleDbCommandBuilder(dataAdapter)
        Dim dsNewRow As DataRow
        dsNewRow = dataSet.Tables("dtbClients1").NewRow()
        dsNewRow.Item(1) = txtFORENAME.Text
        dsNewRow.Item(2) = txtSURNAME.Text
        dsNewRow.Item(3) = txtDOB.Text
        dsNewRow.Item(4) = txtADDRESS.Text
        dsNewRow.Item(5) = txtPARENT.Text
        dsNewRow.Item(6) = txtPHONE.Text
        dsNewRow.Item(7) = txtEMAIL.Text

        dataSet.Tables("dtbClients1").Rows.Add(dsNewRow)
        dataAdapter.Update(dataSet, "dtbClients1")
        MsgBox("New Record added to the Database")

    End Sub

End Class
