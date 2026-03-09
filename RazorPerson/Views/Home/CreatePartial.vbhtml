@ModelType RazorPerson.Person
<h2 class="text-primary">Ajouter une personne (Partial)</h2>
@Using Html.BeginForm()
@Html.ValidationSummary(True, "Veuillez corriger les erreurs")
                @Html.Partial("_FormulairePersonne")
                               @<button type="submit" class="btn btn-success">Ajouter</button>
                                                @Html.ActionLink("Annuler", "Index", Nothing, New With {.class = "btn btn-default"})End Using

@Section scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section