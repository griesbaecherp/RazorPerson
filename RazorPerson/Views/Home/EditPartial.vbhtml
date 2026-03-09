@ModelType RazorPerson.Person
<h2 class="text-primary">Modifier une personne (Partial)</h2>
@Using Html.BeginForm()
@Html.ValidationSummary(True, "Veuillez corriger les erreurs")
                @Html.HiddenFor(Function(m) m.Id)
                                @Html.Partial("_FormulairePersonne")
                                               @<button type="submit" class="btn btn-warning">Modifier</button>
                                                                @Html.ActionLink("Annuler", "Index", Nothing, New With {.class = "btn btn-default"})End Using

@Section scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section