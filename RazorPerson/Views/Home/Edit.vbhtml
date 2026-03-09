@ModelType RazorPerson.Person
<h2 class="text-primary">Modifier une personne</h2>
@Using Html.BeginForm()
@Html.ValidationSummary(True, "Veuillez corriger les erreurs")
                @Html.HiddenFor(Function(m) m.Id)
                                @<div class="form-group">
                                    @Html.LabelFor(Function(m) m.Name)
                                    @Html.TextBoxFor(Function(m) m.Name, New With {.class = "form-control"})
                                    @Html.ValidationMessageFor(Function(m) m.Name, "", New With {.class = "text-danger"})
                                </div>
                                               @<div class="form-group">
                                                    @Html.LabelFor(Function(m) m.Age)
                                                    @Html.TextBoxFor(Function(m) m.Age, New With {.class = "form-control"})
                                                    @Html.ValidationMessageFor(Function(m) m.Age, "", New With {.class = "text-danger"})
                                                </div>
                                                               @<button type="submit" class="btn btn-warning">Modifier</button>
                                                                                @Html.ActionLink("Annuler", "Index", Nothing, New With {.class = "btn btn-default"})End Using

@Section scripts
    @Scripts.Render("~/bundles/jqueryval")
End Section