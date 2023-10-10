# About

Basic example of demonstrating how to set selected value for a select element.

The **select** is set to a page property

```csharp
[BindProperty]
public string Priority { get; set; }
```

As presented **Priority** has a value of `Amber`.

OnPost if **Priority** is null a message is presented indicating nothing was selected while if there is a selection the message indicates the selection.

> **Note**
> @Html.Raw(Model.Message) is used and for a real application should be used sparingly so not to give hackers a way into your app. I used it for convenience sake, keeps the code simple.

Of course for a real application there would be validation against the Model for the Page and handled accordingly.

## Random select

Given a list of colors

```csharp
public class StaticData
{
    public static List<string> Colors 
        => new() { "","Green", "Amber", "Red" };
}
```

We can use `Random.Shared.Next()` to get a random color.

```csharp
public void OnGet()
{
    Priority = StaticData
        .Colors
        .OrderBy(x => Random.Shared.Next())
        .ToList()
        .FirstOrDefault();
}
```

## Accessibility

:small_orange_diamond: Index page is WCAG AA compliant

- Has a role = main for the form
- H1 is present
- There is a label associated with the select