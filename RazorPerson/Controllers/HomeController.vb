Imports System.Web.Mvc
Imports RazorPerson

Public Class HomeController
    Inherits Controller

    ' Liste partagée en mémoire
    Shared liste As New List(Of Person) From {
        New Person() With {.Id = 1, .Name = "Pierre", .Age = 30},
        New Person() With {.Id = 2, .Name = "Jacques", .Age = 25},
        New Person() With {.Id = 3, .Name = "Paul", .Age = 40}
    }

    ' READ
    Public Function Index() As ActionResult
        Return View(liste)
    End Function

    ' CREATE - affiche le formulaire
    Public Function Create() As ActionResult
        Return View()
    End Function

    ' CREATE - traite le formulaire
    <HttpPost>
    Public Function Create(p As Person) As ActionResult
        If ModelState.IsValid Then
            p.Id = liste.Max(Function(x) x.Id) + 1
            liste.Add(p)
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function

    ' EDIT - affiche le formulaire
    Public Function Edit(id As Integer) As ActionResult
        Dim p = liste.FirstOrDefault(Function(x) x.Id = id)
        Return View(p)
    End Function

    ' EDIT - traite le formulaire
    <HttpPost>
    Public Function Edit(p As Person) As ActionResult
        If ModelState.IsValid Then
            Dim existing = liste.FirstOrDefault(Function(x) x.Id = p.Id)
            existing.Name = p.Name
            existing.Age = p.Age
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function

    ' DELETE - affiche la confirmation
    Public Function Delete(id As Integer) As ActionResult
        Dim p = liste.FirstOrDefault(Function(x) x.Id = id)
        Return View(p)
    End Function

    ' DELETE - effectue la suppression
    <HttpPost>
    <ActionName("Delete")>
    Public Function DeleteConfirmed(id As Integer) As ActionResult
        Dim p = liste.FirstOrDefault(Function(x) x.Id = id)
        liste.Remove(p)
        Return RedirectToAction("Index")
    End Function

    ' Affiche la vue Ajax
    Public Function IndexAjax() As ActionResult
        Return View()
    End Function
    ' Affiche la vue Ajax
    Public Function IndexAjaxToast() As ActionResult
        Return View()
    End Function

    ' Retourne la liste en JSON
    Public Function GetPersonnes() As JsonResult
        Return Json(liste, JsonRequestBehavior.AllowGet)
    End Function
    ' DELETE en AJAX
    <HttpPost>
    Public Function DeleteAjax(id As Integer) As JsonResult
        Dim p = liste.FirstOrDefault(Function(x) x.Id = id)
        liste.Remove(p)
        Return Json(New With {.success = True})
    End Function

    ' CREATE en AJAX
    <HttpPost>
    Public Function CreateAjax(p As Person) As JsonResult
        p.Id = liste.Max(Function(x) x.Id) + 1
        liste.Add(p)
        Return Json(New With {.success = True})
    End Function

    ' EDIT en AJAX
    <HttpPost>
    Public Function EditAjax(p As Person) As JsonResult
        Dim existing = liste.FirstOrDefault(Function(x) x.Id = p.Id)
        existing.Name = p.Name
        existing.Age = p.Age
        Return Json(New With {.success = True})
    End Function

    ' CREATE Partial - affiche le formulaire
    Public Function CreatePartial() As ActionResult
        Return View()
    End Function

    ' CREATE Partial - traite le formulaire
    <HttpPost>
    Public Function CreatePartial(p As Person) As ActionResult
        If ModelState.IsValid Then
            p.Id = liste.Max(Function(x) x.Id) + 1
            liste.Add(p)
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function

    ' EDIT Partial - affiche le formulaire
    Public Function EditPartial(id As Integer) As ActionResult
        Dim p = liste.FirstOrDefault(Function(x) x.Id = id)
        Return View(p)
    End Function

    ' EDIT Partial - traite le formulaire
    <HttpPost>
    Public Function EditPartial(p As Person) As ActionResult
        If ModelState.IsValid Then
            Dim existing = liste.FirstOrDefault(Function(x) x.Id = p.Id)
            existing.Name = p.Name
            existing.Age = p.Age
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function
    ' INDEX Partial
    Public Function IndexPartial() As ActionResult
        Return View(liste)
    End Function
    ' DELETE Partial - affiche la confirmation
    Public Function DeletePartial(id As Integer) As ActionResult
        Dim p = liste.FirstOrDefault(Function(x) x.Id = id)
        Return View(p)
    End Function

    ' DELETE Partial - effectue la suppression
    <HttpPost>
    <ActionName("DeletePartial")>
    Public Function DeletePartialConfirmed(id As Integer) As ActionResult
        Dim p = liste.FirstOrDefault(Function(x) x.Id = id)
        liste.Remove(p)
        Return RedirectToAction("IndexPartial")
    End Function
End Class