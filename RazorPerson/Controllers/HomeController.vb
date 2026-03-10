Imports System.Web.Mvc
Imports RazorPerson

Public Class HomeController
    Inherits Controller

    Private ReadOnly _repo As New PersonRepository()

    ' READ
    Public Function Index() As ActionResult
        ViewBag.Title = "Liste des personnes"
        Return View(_repo.GetAll())
    End Function

    ' CREATE - affiche le formulaire
    Public Function Create() As ActionResult
        Return View()
    End Function

    ' CREATE - traite le formulaire
    <HttpPost>
    Public Function Create(p As Person) As ActionResult
        If ModelState.IsValid Then
            _repo.Insert(p)
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function

    ' EDIT - affiche le formulaire
    Public Function Edit(id As Integer) As ActionResult
        Return View(_repo.GetById(id))
    End Function

    ' EDIT - traite le formulaire
    <HttpPost>
    Public Function Edit(p As Person) As ActionResult
        If ModelState.IsValid Then
            _repo.Update(p)
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function

    ' DELETE - affiche la confirmation
    Public Function Delete(id As Integer) As ActionResult
        Return View(_repo.GetById(id))
    End Function

    ' DELETE - effectue la suppression
    <HttpPost>
    <ActionName("Delete")>
    Public Function DeleteConfirmed(id As Integer) As ActionResult
        _repo.Delete(id)
        Return RedirectToAction("Index")
    End Function

    ' Affiche la vue Ajax
    Public Function IndexAjax() As ActionResult
        Return View()
    End Function

    ' Affiche la vue Ajax Toast
    Public Function IndexAjaxToast() As ActionResult
        Return View()
    End Function

    ' Retourne la liste en JSON
    Public Function GetPersonnes() As JsonResult
        Return Json(_repo.GetAll(), JsonRequestBehavior.AllowGet)
    End Function

    ' DELETE en AJAX
    <HttpPost>
    Public Function DeleteAjax(id As Integer) As JsonResult
        _repo.Delete(id)
        Return Json(New With {.success = True})
    End Function

    ' CREATE en AJAX
    <HttpPost>
    Public Function CreateAjax(p As Person) As JsonResult
        _repo.Insert(p)
        Return Json(New With {.success = True})
    End Function

    ' EDIT en AJAX
    <HttpPost>
    Public Function EditAjax(p As Person) As JsonResult
        _repo.Update(p)
        Return Json(New With {.success = True})
    End Function

    ' CREATE Partial
    Public Function CreatePartial() As ActionResult
        Return View()
    End Function

    <HttpPost>
    Public Function CreatePartial(p As Person) As ActionResult
        If ModelState.IsValid Then
            _repo.Insert(p)
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function

    ' EDIT Partial
    Public Function EditPartial(id As Integer) As ActionResult
        Return View(_repo.GetById(id))
    End Function

    <HttpPost>
    Public Function EditPartial(p As Person) As ActionResult
        If ModelState.IsValid Then
            _repo.Update(p)
            Return RedirectToAction("Index")
        End If
        Return View(p)
    End Function

    ' INDEX Partial
    Public Function IndexPartial() As ActionResult
        Return View(_repo.GetAll())
    End Function

    ' DELETE Partial
    Public Function DeletePartial(id As Integer) As ActionResult
        Return View(_repo.GetById(id))
    End Function

    <HttpPost>
    <ActionName("DeletePartial")>
    Public Function DeletePartialConfirmed(id As Integer) As ActionResult
        _repo.Delete(id)
        Return RedirectToAction("IndexPartial")
    End Function

End Class