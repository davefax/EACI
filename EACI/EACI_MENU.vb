﻿Option Strict Off
Imports System
Imports System.IO
Imports ProductStructureTypeLib
Imports MECMOD
Imports DRAFTINGITF
Imports HybridShapeTypeLib
Imports INFITF
Imports AdvancedDataGridView
Public Class EACI_MENU

    Private Sub Label1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim PL As New LoginForm

        PL.Show()

        Me.Hide()
        'Button2.Enabled = True
        'Button3.Enabled = True
        'Button4.Enabled = True
        'Button5.Enabled = True
        'Button6.Enabled = True
        'Button1.Enabled = False
    End Sub

    Private Sub HLY_MENU_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If loginstatus = False Then

            Button1.Enabled = True
            Button2.Enabled = False
            Button3.Enabled = False
            Button4.Enabled = False
            Button6.Enabled = False
        Else
            Button1.Enabled = False
            Button2.Enabled = True
            Button3.Enabled = True
            Button4.Enabled = True
            Button6.Enabled = True
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim savefrm As New BomSave

        savefrm.Show()

    End Sub


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        catia = GetObject(, "CATIA.Application")
        If Err.Number <> 0 Then
            catia = CreateObject("CATIA.Application")
            catia.Visible = True
        End If
        Dim oDocument As Document = catia.ActiveDocument

        '    Try
        Dim oDrawingDoc As DrawingDocument = oDocument
            If System.IO.File.Exists(oDrawingDoc.FullName) = False Then
                MsgBox("请先保存文件！")
                Exit Sub
            End If
        Dim fullname = oDrawingDoc.FullName
        Dim name = oDrawingDoc.Name

        Dim file As Aras.IOM.Item = Addfile(fullname, name)

        Dim oSheet As DrawingSheet
        For Each oSheet In oDrawingDoc.Sheets
            Dim th As String = oSheet.Name
            Dim part As Aras.IOM.Item = findexistpart(th)
            If Not part Is Nothing Then
                partfile(part, file)
            End If

        Next
        '   Catch ex As Exception
        '      MsgBox("请打开正确的工程图")
        '   End Try

        MsgBox("保存成功！")

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        conn.Logout()
        Me.Close()
        System.Windows.Forms.Application.Exit()

    End Sub

    Private Sub EACI_MENU_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        System.Windows.Forms.Application.Exit()
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Me.Hide()
        EACI_create.Show()
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

        Dim up As New upload
        up.Show()
    End Sub
End Class