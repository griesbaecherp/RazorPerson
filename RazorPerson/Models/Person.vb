Imports System.ComponentModel.DataAnnotations

Public Class Person
    Public Property Id As Integer

    <Required(ErrorMessage:="Le nom est obligatoire")>
    <StringLength(50, ErrorMessage:="Le nom ne peut pas dépasser 50 caractères")>
    Public Property Name As String

    <Required(ErrorMessage:="L'âge est obligatoire")>
    <Range(1, 120, ErrorMessage:="L'âge doit être compris entre 1 et 120")>
    Public Property Age As Integer

    Public Property HtmlContent As String
End Class