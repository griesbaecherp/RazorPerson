@ModelType RazorPerson.Person

<div class="form-group">
    @Html.LabelFor(Function(m) m.Name)
    @Html.TextBoxFor(Function(m) m.Name, New With {.class = "form-control"})
    @Html.ValidationMessageFor(Function(m) m.Name, "", New With {.class = "text-danger"})
</div>
<div class="form-group">
    @Html.LabelFor(Function(m) m.Age)
    @Html.TextBoxFor(Function(m) m.Age, New With {.class = "form-control"})
    @Html.ValidationMessageFor(Function(m) m.Age, "", New With {.class = "text-danger"})
</div>