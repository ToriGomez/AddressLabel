'Tori Gomez
'RCET0265
'Spring 2021
'Address Label Program
'https://github.com/ToriGomez/AddressLabel.git

Option Explicit On
Option Strict On
Public Class AddressLabelForm
    'Sub doesn't allow display to be selected until mailing adresses is validated.
    Private Sub AddressLabelForm_Load(sender As Object, e As EventArgs) Handles Me.Load
        DisplayButton.Enabled = False
    End Sub
    'Formatting of the Address label created from user.
    Private Sub DisplayButton_Click(sender As Object, e As EventArgs) Handles DisplayButton.Click
        DisplayLabel.Text = (FirstNameTextBox.Text) & " " & (LastNameTextBox.Text) _
            & vbNewLine & (StreetAddressTextBox.Text) & vbNewLine & (CityTextBox.Text) _
            & ", " & (StateTextBox.Text) & " " & (ZipTextBox.Text)
    End Sub
    'Sub to Clear all mailing textboxes when clear button is selected.
    Private Sub ClearButton_Click(sender As Object, e As EventArgs) Handles ClearButton.Click
        FirstNameTextBox.Text = ""
        LastNameTextBox.Text = ""
        StreetAddressTextBox.Text = ""
        CityTextBox.Text = ""
        StateTextBox.Text = ""
        ZipTextBox.Text = ""
        DisplayLabel.Text = ""
        DisplayButton.Enabled = False
    End Sub
    'Sub for Cancel button to quit program.
    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Me.Close()
    End Sub
    'Function that validates if all mailing adderess text boxes are filled.
    Function ValidateFields() As Boolean
        Dim problemMessage As String
        Dim status As Boolean = True
        If (ZipTextBox.Text) = "" Then
            problemMessage &= "Zip Code is required" & vbNewLine
            status = False
        End If
        If (StateTextBox.Text) = "" Then
            problemMessage &= "State name is required" & vbNewLine
            status = False
        End If
        If (CityTextBox.Text) = "" Then
            problemMessage &= "City name is required" & vbNewLine
            status = False
        End If
        If (FirstNameTextBox.Text) = "" Then
            problemMessage &= "First name is required" & vbNewLine
            status = False
        End If
        If (LastNameTextBox.Text) = "" Then
            problemMessage &= "Last name is required" & vbNewLine
            status = False
        End If
        Return status
    End Function
    'Sub checks to see if all Boxes in Mailing Address is filled.
    Private Sub InputGroupBox_Validated(sender As Object, e As EventArgs) Handles InputGroupBox.Validated
        ValidateFields()
        If ValidateFields() = False Then
            DisplayButton.Enabled = False
            MsgBox("All boxes in Mailing Address are required.")
        Else
            DisplayButton.Enabled = True
        End If
    End Sub
End Class
