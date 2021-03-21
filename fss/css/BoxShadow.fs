namespace Fss

open FssTypes

[<AutoOpen>]
module BoxShadow =
    // https://developer.mozilla.org/en-US/docs/Web/CSS/box-shadow
    let rec private boxShadowToString =
        function
            | BoxShadow.Color (x, y, color) ->
                sprintf "%s %s %s"
                    (Types.sizeToString x)
                    (Types.sizeToString y)
                    (Types.colorToString color)
            | BoxShadow.BlurColor (x, y, blur, color) ->
                sprintf "%s %s %s %s"
                    (Types.sizeToString x)
                    (Types.sizeToString y)
                    (Types.sizeToString blur)
                    (Types.colorToString color)
            | BoxShadow.BlurSpreadColor (x, y, blur, spread, color) ->
                sprintf "%s %s %s %s %s"
                    (Types.sizeToString x)
                    (Types.sizeToString y)
                    (Types.sizeToString blur)
                    (Types.sizeToString spread)
                    (Types.colorToString color)
            | BoxShadow.Inset shadow ->
                sprintf "inset %s" <| boxShadowToString shadow

    let private boxShadowValue value = Types.cssValue Types.Property.BoxShadow value
    type BoxShadow =
        static member Color (x: Types.Size, y: Types.Size, color: Types.Color) = BoxShadow.Color(x, y, color)
        static member BlurColor (x: Types.Size, y: Types.Size, blur: Types.Size, color: Types.Color) =
                BoxShadow.BlurColor(x, y, blur, color)
        static member BlurSpreadColor (x: Types.Size, y: Types.Size, blur: Types.Size, spread: Types.Size, color: Types.Color) =
                BoxShadow.BlurSpreadColor(x, y, blur, spread, color)

    /// Supply a list of box shadows to be applied to the element.
    let BoxShadows (shadows: Types.BoxShadow list): CssProperty =
        shadows
        |> Utilities.Helpers.combineComma boxShadowToString
        |> boxShadowValue

    /// Can be used to invert box shadow
    let Inset (shadow: Types.BoxShadow) = BoxShadow.Inset shadow