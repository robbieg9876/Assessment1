Imports System.Drawing.Printing
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
    Private Sub btnOPEN_Click(sender As Object, e As EventArgs) Handles btnOPEN.Click
        y = InputBox("How many records?")
        y = y - 1
        total = 0
        prepare = True
        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
        dbSource = "Data Source = C:\Users\robbi\dtbClients1.mdb"
        con.ConnectionString = dbProvider & dbSource
        con.Open()
        MsgBox("Database is now open")
        sql = "SELECT * FROM tblClients1"
        dataAdapter = New OleDb.OleDbDataAdapter(sql, con)
        dataAdapter.Fill(dataSet, "dtbClients1")
        x = 0
        txtFORENAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(1)
        txtSURNAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(2)
        txtRATE.Text = dataSet.Tables("dtbClients1").Rows(x).Item(5)
        txtFIXED.Text = dataSet.Tables("dtbClients1").Rows(x).Item(4)
    End Sub
    Private Sub btnCLOSE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLOSE.Click
        con.Close()
        MsgBox("Database is now Closed")
        txtFORENAME.Clear()
        txtSURNAME.Clear()
        txtFORENAME.Clear()
        txtSURNAME.Clear()
        txtRATE.Clear()
        txtFIXED.Clear()

    End Sub



    Private Sub btnPREVIOUS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPREVIOUS.Click
        x = x - 1
        If x < 0 Then
            MsgBox("NO PREVIOUS RECORDS")
            x = x + 1
        End If
        txtFORENAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(1)
        txtSURNAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(2)

        txtRATE.Text = dataSet.Tables("dtbClients1").Rows(x).Item(5)
        txtFIXED.Text = dataSet.Tables("dtbClients1").Rows(x).Item(4)
    End Sub

    Private Sub btnNEXT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNEXT.Click
        x = x + 1
        If x > y Then
            MsgBox("NO MORE RECORDS")
            x = x - 1
        End If
        txtFORENAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(1)
        txtSURNAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(2)
        txtRATE.Text = dataSet.Tables("dtbClients1").Rows(x).Item(5)
        txtFIXED.Text = dataSet.Tables("dtbClients1").Rows(x).Item(4)
    End Sub

    Private Sub btnLAST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLAST.Click
        x = y
        txtFORENAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(1)
        txtSURNAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(2)
        txtRATE.Text = dataSet.Tables("dtbClients1").Rows(x).Item(5)
        txtFIXED.Text = dataSet.Tables("dtbClients1").Rows(x).Item(4)
    End Sub

    Private Sub btnADDNEW_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnADDNEW.Click
        btnCOMMIT.Enabled = True
        btnADDNEW.Enabled = False
        btnUPDATE.Enabled = False
        btnDELETE.Enabled = False
        txtFORENAME.Clear()
        txtSURNAME.Clear()


    End Sub

    Private Sub btnUPDATE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUPDATE.Click
        Dim commandBuilder As New OleDb.OleDbCommandBuilder(dataAdapter)
        dataSet.Tables("dtbClients1").Rows(x).Item(1) = txtFORENAME.Text
        dataSet.Tables("dtbClients1").Rows(x).Item(2) = txtSURNAME.Text
        dataSet.Tables("dtbClients1").Rows(x).Item(4) = txtFIXED.Text
        dataSet.Tables("dtbClients1").Rows(x).Item(5) = txtRATE.Text
        dataAdapter.Update(dataSet, "dtbClients1")
        MsgBox("Data updated")

    End Sub

    Private Sub btnCLEAR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCLEAR.Click
        btnCOMMIT.Enabled = False
        btnADDNEW.Enabled = True
        btnUPDATE.Enabled = True
        btnDELETE.Enabled = True

    End Sub

    Private Sub btnCOMMIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCOMMIT.Click
        Dim commandBuilder As New OleDb.OleDbCommandBuilder(dataAdapter)
        Dim dsNewRow As DataRow
        dsNewRow = dataSet.Tables("dtbClients1").NewRow()
        dsNewRow.Item(1) = txtFORENAME.Text
        dsNewRow.Item(2) = txtSURNAME.Text
        dsNewRow.Item(3) = paytype
        dsNewRow.Item(4) = txtFIXED.Text
        dsNewRow.Item(5) = txtRATE.Text
        dataSet.Tables("dtbClients1").Rows.Add(dsNewRow)
        dataAdapter.Update(dataSet, "dtbClients1")
        MsgBox("New Record added to the Database")
        btnCOMMIT.Enabled = False
        btnADDNEW.Enabled = True
        btnUPDATE.Enabled = True
        btnDELETE.Enabled = True

    End Sub

    Private Sub btnDELETE_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDELETE.Click
        If MessageBox.Show("Do you really want to Delete this Record?",
"Delete", MessageBoxButtons.YesNo,
MessageBoxIcon.Warning) = DialogResult.No Then

            MsgBox("Operation Cancelled")
            Exit Sub
        End If

        Dim commandBuilder As New OleDb.OleDbCommandBuilder(dataAdapter)
        dataSet.Tables("dtbClients1").Rows(x).Delete()
        y = y - 1
        dataAdapter.Update(dataSet, "dtbClients1")
        x = x - 1
        txtFORENAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(1)
        txtSURNAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(2)
        txtRATE.Text = dataSet.Tables("dtbClients1").Rows(x).Item(5)
        txtFIXED.Text = dataSet.Tables("dtbClients1").Rows(x).Item(4)
    End Sub

    Private Sub txtSURNAME_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSURNAME.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub btnSUBMIT_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim login As Boolean
        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
        dbSource = "Data Source = C:\Users\robbi\dtbLOGIN.mdb"
        con.ConnectionString = dbProvider & dbSource
        con.Open()
        sql = "SELECT * FROM tblLOGIN"
        dataAdapter = New OleDb.OleDbDataAdapter(sql, con)
        dataAdapter.Fill(dataSet, "dtbLOGIN")
        login = False
        If txtUSERNAME.Text = dataSet.Tables("dtbLOGIN").Rows(0).Item(1) And txtPASSWORD.Text = dataSet.Tables("dtbLOGIN").Rows(0).Item(2) Then
            MsgBox("Access Granted")
            login = True
            txtUSERNAME.Text = ""
            txtPASSWORD.Text = ""
            con.Close()
            TabControl2.Visible = True
            TabControl1.Visible = False
        Else
            MsgBox("Access Denied")
            txtUSERNAME.Text = ""
            txtPASSWORD.Text = ""
            con.Close()
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    End Sub

    Private Sub btnLOGIN_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        TabControl1.Visible = False
        TabControl2.Visible = True
        MsgBox("Logged in")
    End Sub

    Private Sub TabPage3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub btnFIRST_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFIRST.Click
        x = 0
        txtFORENAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(1)
        txtSURNAME.Text = dataSet.Tables("dtbClients1").Rows(x).Item(2)
        txtRATE.Text = dataSet.Tables("dtbClients1").Rows(x).Item(5)
        txtFIXED.Text = dataSet.Tables("dtbClients1").Rows(x).Item(4)
    End Sub


    Private Sub DateTimePicker1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbFIXED.CheckedChanged
        lblFIXED.Visible = True
        txtFIXED.Visible = True
        lblRATE.Visible = False
        txtRATE.Visible = False
    End Sub

    Private Sub RadioButton2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbVARIABLE.CheckedChanged
        lblRATE.Visible = True
        txtRATE.Visible = True
        lblFIXED.Visible = False
        txtFIXED.Visible = False
    End Sub

    Private Sub WebBrowser1_DocumentCompleted(ByVal sender As System.Object, ByVal e As System.Windows.Forms.WebBrowserDocumentCompletedEventArgs)

    End Sub





    Private Sub btnCONFIRM_Click(sender As Object, e As EventArgs) Handles btnCONFIRM.Click
        If rbFIXED.Checked = True Then
            lblFIXED.Visible = True
            txtFIXED.Visible = True
            lblRATE.Visible = False
            txtRATE.Visible = False
            paytype = "Fixed"
        ElseIf rbVARIABLE.Checked = True Then
            lblFIXED.Visible = False
            txtFIXED.Visible = False
            lblRATE.Visible = True
            txtRATE.Visible = True
            paytype = "Variable"
        End If
    End Sub

    Private Sub TextBox5_TextChanged(sender As Object, e As EventArgs)

    End Sub


    Private Sub btnLOGOUT_Click_1(sender As Object, e As EventArgs) Handles btnLOGOUT.Click
        TabControl1.Visible = True
        TabControl2.Visible = False
        MsgBox("Logged Out")

    End Sub

    Private Sub TabPage1_Click(sender As Object, e As EventArgs) Handles TabPage1.Click

    End Sub

    Private Sub btnLOGIN_Click_1(sender As Object, e As EventArgs) Handles btnLOGIN.Click
        Dim login As Boolean
        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;"
        dbSource = "Data Source = C:\Users\robbi\dtbLOGIN.mdb"
        con.ConnectionString = dbProvider & dbSource
        con.Open()
        sql = "SELECT * FROM tblLOGIN"
        dataAdapter = New OleDb.OleDbDataAdapter(sql, con)
        dataAdapter.Fill(dataSet, "dtbLOGIN")
        login = False
        If txtUSERNAME.Text = dataSet.Tables("dtbLOGIN").Rows(0).Item(1) And txtPASSWORD.Text = dataSet.Tables("dtbLOGIN").Rows(0).Item(2) Then
            MsgBox("Access Granted")
            login = True
            txtUSERNAME.Text = ""
            txtPASSWORD.Text = ""
            con.Close()
            TabControl1.Visible = False
            TabControl2.Visible = True

        Else
            MsgBox("Access Denied")
            txtUSERNAME.Text = ""
            txtPASSWORD.Text = ""
            con.Close()
        End If
    End Sub

    Private Sub TextBox11_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Invoicing_Click(sender As Object, e As EventArgs) Handles Invoicing.Click

    End Sub

    Private Sub TextBox33_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TextBox102_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub TabPage5_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt00_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker10_ValueChanged(sender As Object, e As EventArgs)
        DateTimePicker10.Format = DateTimePickerFormat.Custom
        DateTimePicker10.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker10.Value = "6 / 1 / 2018" Then

        Else
            TextBox100.Text = DateTimePicker10.Value
        End If
    End Sub

    Private Sub TabPage7_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker2_ValueChanged(sender As Object, e As EventArgs)
        DateTimePicker2.Format = DateTimePickerFormat.Custom
        DateTimePicker2.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker2.Value = "6 / 1 / 2018" Then

        Else
            txt20.Text = DateTimePicker2.Value
        End If
    End Sub

    Private Sub DateTimePicker0_ValueChanged(sender As Object, e As EventArgs)
        DateTimePicker0.Format = DateTimePickerFormat.Custom
        DateTimePicker0.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker0.Value = "6 / 1 / 2018" Then

        Else
            txt00.Text = DateTimePicker0.Value
        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged_1(sender As Object, e As EventArgs)
        DateTimePicker1.Format = DateTimePickerFormat.Custom
        DateTimePicker1.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker1.Value = "6 / 1 / 2018" Then

        Else
            txt10.Text = DateTimePicker1.Value
        End If
    End Sub

    Private Sub DateTimePicker4_ValueChanged(sender As Object, e As EventArgs)
        DateTimePicker4.Format = DateTimePickerFormat.Custom
        DateTimePicker4.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker4.Value = "6 / 1 / 2018" Then

        Else
            TextBox40.Text = DateTimePicker4.Value
        End If
    End Sub

    Private Sub DateTimePicker3_ValueChanged(sender As Object, e As EventArgs)
        DateTimePicker3.Format = DateTimePickerFormat.Custom
        DateTimePicker3.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker3.Value = "6 / 1 / 2018" Then

        Else
            txt30.Text = DateTimePicker3.Value
        End If
    End Sub

    Private Sub txt10_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker5_ValueChanged(sender As Object, e As EventArgs)
        DateTimePicker5.Format = DateTimePickerFormat.Custom
        DateTimePicker5.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker5.Value = "6 / 1 / 2018" Then

        Else
            TextBox50.Text = DateTimePicker5.Value
        End If
    End Sub

    Private Sub DateTimePicker6_ValueChanged(sender As Object, e As EventArgs)
        DateTimePicker6.Format = DateTimePickerFormat.Custom
        DateTimePicker6.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker6.Value = "6 / 1 / 2018" Then

        Else
            TextBox60.Text = DateTimePicker6.Value
        End If
    End Sub

    Private Sub DateTimePicker7_ValueChanged(sender As Object, e As EventArgs)
        DateTimePicker7.Format = DateTimePickerFormat.Custom
        DateTimePicker7.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker7.Value = "6 / 1 / 2018" Then

        Else
            TextBox70.Text = DateTimePicker7.Value
        End If
    End Sub

    Private Sub DateTimePicker8_ValueChanged(sender As Object, e As EventArgs)
        DateTimePicker8.Format = DateTimePickerFormat.Custom
        DateTimePicker8.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker8.Value = "6 / 1 / 2018" Then

        Else
            TextBox80.Text = DateTimePicker8.Value
        End If
    End Sub

    Private Sub DateTimePicker9_ValueChanged(sender As Object, e As EventArgs)
        DateTimePicker9.Format = DateTimePickerFormat.Custom
        DateTimePicker9.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker9.Value = "6 / 1 / 2018" Then

        Else
            TextBox90.Text = DateTimePicker9.Value
        End If
    End Sub


    Private Sub txtRATE_TextChanged(sender As Object, e As EventArgs) Handles txtRATE.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        PrintForm1.Print()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnPREPARE.Click
        If prepare = False Then
            Me.BackColor = Color.White
            TabControl2.SelectedIndex = 1
            DateTimePicker0.Visible = False
            DateTimePicker1.Visible = False
            DateTimePicker2.Visible = False
            DateTimePicker3.Visible = False
            DateTimePicker4.Visible = False
            DateTimePicker5.Visible = False
            DateTimePicker6.Visible = False
            DateTimePicker7.Visible = False
            DateTimePicker8.Visible = False
            DateTimePicker9.Visible = False
            DateTimePicker10.Visible = False
            DateTimePicker11.Visible = False
            DateTimePicker12.Visible = False
            DomainUpDown11.Visible = False
            DomainUpDown12.Visible = False
            DomainUpDown13.Visible = False
            DomainUpDown14.Visible = False
            DomainUpDown15.Visible = False
            DomainUpDown16.Visible = False
            DomainUpDown17.Visible = False
            DomainUpDown18.Visible = False
            DomainUpDown19.Visible = False
            DomainUpDown20.Visible = False
            DomainUpDown21.Visible = False
            btnSAVE.Visible = False
            btnPASTE.Visible = False
            btnTOTAL.Visible = False
            btnPREPARE.Text = "Cancel"
            prepare = True
        Else
            Me.BackColor = Color.Violet
            TabControl2.SelectedIndex = 1
            DateTimePicker0.Visible = True
            DateTimePicker1.Visible = True
            DateTimePicker2.Visible = True
            DateTimePicker3.Visible = True
            DateTimePicker4.Visible = True
            DateTimePicker5.Visible = True
            DateTimePicker6.Visible = True
            DateTimePicker7.Visible = True
            DateTimePicker8.Visible = True
            DateTimePicker9.Visible = True
            DateTimePicker10.Visible = True
            DateTimePicker11.Visible = True
            DateTimePicker12.Visible = True
            DomainUpDown11.Visible = True
            DomainUpDown12.Visible = True
            DomainUpDown13.Visible = True
            DomainUpDown14.Visible = True
            DomainUpDown15.Visible = True
            DomainUpDown16.Visible = True
            DomainUpDown17.Visible = True
            DomainUpDown18.Visible = True
            DomainUpDown19.Visible = True
            DomainUpDown20.Visible = True
            DomainUpDown21.Visible = True
            btnSAVE.Visible = True
            btnPASTE.Visible = True
            btnTOTAL.Visible = True
            btnPREPARE.Text = "Prepare"
            prepare = False
        End If
    End Sub

    Private Sub TabPage3_Click_1(sender As Object, e As EventArgs) Handles TabPage3.Click

    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        TextBox1.Text = txtFORENAME.Text
    End Sub

    Private Sub Label18_Click(sender As Object, e As EventArgs) Handles Label18.Click

    End Sub


    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSAVE.Click
        filename = "C:\Users\robbi\invoice"
        PrintForm2.PrintFileName = filename
        PrintForm2.Print()
    End Sub

    Private Sub DateTimePicker11_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker11.ValueChanged
        DateTimePicker11.Format = DateTimePickerFormat.Custom
        DateTimePicker11.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker11.Value = "6 / 1 / 2018" Then

        Else
            TextBox2.Text = DateTimePicker11.Value
        End If
    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnPASTE.Click
        txt13.Text = txt03.Text
        txt23.Text = txt03.Text
        txt33.Text = txt03.Text
        txt43.Text = txt03.Text
        txt53.Text = txt03.Text
        txt63.Text = txt03.Text
        txt73.Text = txt03.Text
        txt83.Text = txt03.Text
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged

    End Sub


    Private Sub TextBox51_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub txt101_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub DateTimePicker12_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker12.ValueChanged
        DateTimePicker12.Format = DateTimePickerFormat.Custom
        DateTimePicker12.CustomFormat = "dd/MM/yyyy"
        If DateTimePicker12.Value = "6 / 1 / 2018" Then

        Else
            TextBox3.Text = DateTimePicker12.Value
        End If
    End Sub

    Private Sub DomainUpDown11_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown11.SelectedItemChanged
        txt01.Text = DomainUpDown11.SelectedItem
        If txt01.Text = "Before School  (8am to 9am)" Then
            txt03.Text = "£4.50*1=£4.50"
            total1 = 4.5
        ElseIf txt01.Text = "After School (3pm to 5pm)" Then
            txt03.Text = "£4.50*2=£9.00"
            total1 = 9
        ElseIf txt01.Text = "Before and After School" Then
            txt03.Text = "£4.50*3 = £13.50"
            total1 = 13.5
        ElseIf txt01.Text = "All day Session" Then
            txt03.Text = "£40"
            total1 = 40
        Else
            txt03.Clear()

        End If
    End Sub

    Private Sub DomainUpDown12_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown12.SelectedItemChanged
        txt11.Text = DomainUpDown12.SelectedItem
        If txt11.Text = "Before School  (8am to 9am)" Then
            txt13.Text = "£4.50*1=£4.50"
            total2 = 4.5
        ElseIf txt11.Text = "After School (3pm to 5pm)" Then
            txt13.Text = "£4.50*2=£9.00"
            total2 = 9
        ElseIf txt11.Text = "Before and After School" Then
            txt13.Text = "£4.50*3 = £13.50"
            total2 = 13.5
        ElseIf txt11.Text = "All day Session" Then
            txt13.Text = "£40"
            total2 = 40
        Else
            txt13.Clear()
        End If
    End Sub

    Private Sub DomainUpDown13_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown13.SelectedItemChanged
        txt21.Text = DomainUpDown13.SelectedItem
        If txt21.Text = "Before School  (8am to 9am)" Then
            txt23.Text = "£4.50*1=£4.50"
            total3 = 4.5
        ElseIf txt21.Text = "After School (3pm to 5pm)" Then
            txt23.Text = "£4.50*2=£9.00"
            total3 = 9
        ElseIf txt21.Text = "Before and After School" Then
            txt23.Text = "£4.50*3 = £13.50"
            total3 = 13.5
        ElseIf txt21.Text = "All day Session" Then
            txt23.Text = "£40"
            total3 = 40
        Else
            txt23.Clear()
        End If

    End Sub

    Private Sub DomainUpDown14_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown14.SelectedItemChanged
        txt31.Text = DomainUpDown14.SelectedItem
        If txt31.Text = "Before School  (8am to 9am)" Then
            txt33.Text = "£4.50*1=£4.50"
            total4 = 4.5
        ElseIf txt31.Text = "After School (3pm to 5pm)" Then
            txt33.Text = "£4.50*2=£9.00"
            total4 = 9
        ElseIf txt31.Text = "Before and After School" Then
            txt33.Text = "£4.50*3 = £13.50"
            total4 = 13.5
        ElseIf txt31.Text = "All day Session" Then
            txt33.Text = "£40"
            total4 = 40
        Else
            txt33.Clear()
        End If
    End Sub

    Private Sub DomainUpDown15_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown15.SelectedItemChanged
        txt41.Text = DomainUpDown15.SelectedItem
        If txt41.Text = "Before School  (8am to 9am)" Then
            txt43.Text = "£4.50*1=£4.50"
            total5 = 4.5
        ElseIf txt41.Text = "After School (3pm to 5pm)" Then
            txt43.Text = "£4.50*2=£9.00"
            total5 = 9
        ElseIf txt41.Text = "Before and After School" Then
            txt43.Text = "£4.50*3 = £13.50"
            total5 = 13.5
        ElseIf txt41.Text = "All day Session" Then
            txt43.Text = "£40"
            total5 = 40
        Else
            txt43.Clear()
        End If
    End Sub

    Private Sub DomainUpDown16_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown16.SelectedItemChanged
        txt51.Text = DomainUpDown16.SelectedItem
        If txt51.Text = "Before School  (8am to 9am)" Then
            txt53.Text = "£4.50*1=£4.50"
            total6 = 4.5
        ElseIf txt51.Text = "After School (3pm to 5pm)" Then
            txt53.Text = "£4.50*2=£9.00"
            total6 = 9
        ElseIf txt51.Text = "Before and After School" Then
            txt53.Text = "£4.50*3 = £13.50"
            total6 = 13.5
        ElseIf txt51.Text = "All day Session" Then
            txt53.Text = "£40"
            total6 = 40
        Else
            txt53.Clear()
        End If
    End Sub

    Private Sub DomainUpDown17_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown17.SelectedItemChanged
        txt61.Text = DomainUpDown17.SelectedItem
        If txt61.Text = "Before School  (8am to 9am)" Then
            txt63.Text = "£4.50*1=£4.50"
            total7 = 4.5
        ElseIf txt61.Text = "After School (3pm to 5pm)" Then
            txt63.Text = "£4.50*2=£9.00"
            total7 = 9
        ElseIf txt61.Text = "Before and After School" Then
            txt63.Text = "£4.50*3 = £13.50"
            total7 = 13.5
        ElseIf txt61.Text = "All day Session" Then
            txt63.Text = "£40"
            total7 = 40
        Else
            txt63.Clear()
        End If
    End Sub

    Private Sub DomainUpDown18_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown18.SelectedItemChanged
        txt71.Text = DomainUpDown18.SelectedItem
        If txt71.Text = "Before School  (8am to 9am)" Then
            txt73.Text = "£4.50*1=£4.50"
            total8 = 4.5
        ElseIf txt71.Text = "After School (3pm to 5pm)" Then
            txt73.Text = "£4.50*2=£9.00"
            total8 = 9
        ElseIf txt71.Text = "Before and After School" Then
            txt73.Text = "£4.50*3 = £13.50"
            total8 = 13.5
        ElseIf txt71.Text = "All day Session" Then
            txt73.Text = "£40"
            total8 = 40
        Else
            txt73.Clear()
        End If
    End Sub

    Private Sub DomainUpDown19_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown19.SelectedItemChanged
        txt81.Text = DomainUpDown19.SelectedItem
        If txt81.Text = "Before School  (8am to 9am)" Then
            txt83.Text = "£4.50*1=£4.50"
            total9 = 4.5
        ElseIf txt81.Text = "After School (3pm to 5pm)" Then
            txt83.Text = "£4.50*2=£9.00"
            total9 = 9
        ElseIf txt81.Text = "Before and After School" Then
            txt83.Text = "£4.50*3 = £13.50"
            total9 = 13.5
        ElseIf txt81.Text = "All day Session" Then
            txt83.Text = "£40"
            total9 = 40
        Else
            txt83.Clear()
        End If
    End Sub

    Private Sub DomainUpDown20_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown20.SelectedItemChanged
        txt91.Text = DomainUpDown20.SelectedItem
        If txt91.Text = "Before School  (8am to 9am)" Then
            txt93.Text = "£4.50*1=£4.50"
            total10 = 4.5
        ElseIf txt91.Text = "After School (3pm to 5pm)" Then
            txt93.Text = "£4.50*2=£9.00"
            total10 = 9
        ElseIf txt91.Text = "Before and After School" Then
            txt93.Text = "£4.50*3 = £13.50"
            total10 = 13.5
        ElseIf txt91.Text = "All day Session" Then
            txt93.Text = "£40"
            total10 = 40
        Else
            txt93.Clear()
        End If
    End Sub
    Private Sub DomainUpDown21_SelectedItemChanged(sender As Object, e As EventArgs) Handles DomainUpDown21.SelectedItemChanged
        txt101.Text = DomainUpDown21.SelectedItem
        If txt101.Text = "Before School  (8am to 9am)" Then
            txt103.Text = "£4.50*1=£4.50"
            total11 = 4.5
        ElseIf txt101.Text = "After School (3pm to 5pm)" Then
            txt103.Text = "£4.50*2=£9.00"
            total11 = 9
        ElseIf txt101.Text = "Before and After School" Then
            txt103.Text = "£4.50*3 = £13.50"
            total11 = 13.5
        ElseIf txt101.Text = "All day Session" Then
            txt103.Text = "£40"
            total11 = 40
        Else
            txt103.Clear()
        End If
    End Sub

    Private Sub btnTOTAL_Click(sender As Object, e As EventArgs) Handles btnTOTAL.Click
        total = total1 + total2 + total3 + total4 + total5 + total6 + total7 + total8 + total9 + total10 + total11
        txtGRANDTOTAL.Text = total.ToString("C2")
    End Sub

    Private Sub txtGRANDTOTAL_TextChanged(sender As Object, e As EventArgs) Handles txtGRANDTOTAL.TextChanged

    End Sub
End Class

