namespace Fss

open Fable.Core

// https://developer.mozilla.org/en-US/docs/Web/CSS/margin
[<AutoOpen>]
module Margin =
    let private marginToString (margin: FssTypes.IMargin) =
        match margin with
        | :? FssTypes.Length as s -> FssTypes.unitHelpers.sizeToString s
        | :? FssTypes.Percent as p -> FssTypes.unitHelpers.percentToString p
        | :? FssTypes.Keywords as k -> FssTypes.masterTypeHelpers.keywordsToString k
        | :? FssTypes.Auto -> FssTypes.masterTypeHelpers.auto
        | _ -> "Unknown margin"

    let private marginValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.Margin
    let private marginValue' = marginToString >> marginValue

    [<Erase>]
    type Margin =
        static member value (width: FssTypes.IMargin) = width |> marginValue'
        static member value (vertical: FssTypes.IMargin, horizontal: FssTypes.IMargin) =
            sprintf "%s %s"
                (marginToString vertical)
                (marginToString horizontal)
            |> marginValue
        static member value (top: FssTypes.IMargin, auto: FssTypes.IMargin, bottom: FssTypes.IMargin) =
            sprintf "%s %s %s"
                (marginToString top)
                (marginToString auto)
                (marginToString bottom)
            |> marginValue
        static member value (top: FssTypes.IMargin, right: FssTypes.IMargin, bottom: FssTypes.IMargin, left: FssTypes.IMargin) =
            sprintf "%s %s %s %s"
                (marginToString top)
                (marginToString right)
                (marginToString bottom)
                (marginToString left)
            |> marginValue
        static member auto = FssTypes.Auto |> marginValue'
        static member inherit' = FssTypes.Inherit |> marginValue'
        static member initial = FssTypes.Initial |> marginValue'
        static member unset = FssTypes.Unset |> marginValue'

    /// <summary>Specifies the margin on all sides of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let Margin' = Margin.value
    let private marginTopValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginTop
    let private marginTopValue' = marginToString >> marginTopValue
    [<Erase>]
    type MarginTop =
        static member value (top: FssTypes.IMargin) = top |> marginTopValue'
        static member auto = FssTypes.Auto |> marginTopValue'
        static member inherit' = FssTypes.Inherit |> marginTopValue'
        static member initial = FssTypes.Initial |> marginTopValue'
        static member unset = FssTypes.Unset |> marginTopValue'

    /// <summary>Specifies the margin on top side of an element.</summary>
    /// <param name="top">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginTop' = MarginTop.value

    let private marginRightValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginRight
    let private marginRightValue' = marginToString >> marginRightValue

    [<Erase>]
    type MarginRight =
        static member value (right: FssTypes.IMargin) = right |> marginRightValue'
        static member auto = FssTypes.Auto |> marginRightValue'
        static member inherit' = FssTypes.Inherit |> marginRightValue'
        static member initial = FssTypes.Initial |> marginRightValue'
        static member unset = FssTypes.Unset |> marginRightValue'

    /// <summary>Specifies the margin on right side of an element.</summary>
    /// <param name="right">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginRight' = MarginRight.value

    let private marginBottomValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBottom
    let private marginBottomValue' = marginToString >> marginBottomValue
    [<Erase>]
    type MarginBottom =
        static member value (bottom: FssTypes.IMargin) = bottom |> marginBottomValue'
        static member auto = FssTypes.Auto |> marginBottomValue'
        static member inherit' = FssTypes.Inherit |> marginBottomValue'
        static member initial = FssTypes.Initial |> marginBottomValue'
        static member unset = FssTypes.Unset |> marginBottomValue'

    /// <summary>Specifies the margin on bottom side of an element.</summary>
    /// <param name="bottom">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginBottom' = MarginBottom.value

    let private marginLeftValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginLeft
    let private marginLeftValue' = marginToString >> marginLeftValue

    [<Erase>]
    type MarginLeft =
        static member value (left: FssTypes.IMargin) = left |> marginLeftValue'
        static member auto = FssTypes.Auto |> marginLeftValue'
        static member inherit' = FssTypes.Inherit |> marginLeftValue'
        static member initial = FssTypes.Initial |> marginLeftValue'
        static member unset = FssTypes.Unset |> marginLeftValue'

    /// <summary>Specifies the margin on left side of an element.</summary>
    /// <param name="left">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>

    let MarginLeft' = MarginLeft.value

    let private marginInlineStartValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginInlineStart
    let private marginInlineStartValue' = marginToString >> marginInlineStartValue

    [<Erase>]
    type MarginInlineStart =
        static member value (margin: FssTypes.IMargin) = margin |> marginInlineStartValue'
        static member auto = FssTypes.Auto |> marginInlineStartValue'
        static member inherit' = FssTypes.Inherit |> marginInlineStartValue'
        static member initial = FssTypes.Initial |> marginInlineStartValue'
        static member unset = FssTypes.Unset |> marginInlineStartValue'

    /// <summary>Specifies the amount of space along the outer starting edge of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginInlineStart' = MarginInlineStart.value

    let private marginInlineEndValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginInlineEnd
    let private marginInlineEndValue' = marginToString >> marginInlineEndValue

    [<Erase>]
    type MarginInlineEnd =
        static member value (margin: FssTypes.IMargin) = margin |> marginInlineEndValue'
        static member auto = FssTypes.Auto |> marginInlineEndValue'
        static member inherit' = FssTypes.Inherit |> marginInlineEndValue'
        static member initial = FssTypes.Initial |> marginInlineEndValue'
        static member unset = FssTypes.Unset |> marginInlineEndValue'

    /// <summary>Specifies the amount of space along the outer ending edge of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginInlineEnd' = MarginInlineEnd.value

    let private marginBlockStartValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBlockStart
    let private marginBlockStartValue' = marginToString >> marginBlockStartValue

    [<Erase>]
    type MarginBlockStart =
        static member value (margin: FssTypes.IMargin) = margin |> marginBlockStartValue'
        static member auto = FssTypes.Auto |> marginBlockStartValue'
        static member inherit' = FssTypes.Inherit |> marginBlockStartValue'
        static member initial = FssTypes.Initial |> marginBlockStartValue'
        static member unset = FssTypes.Unset |> marginBlockStartValue'

    /// <summary>Specifies the amount of start margin of an element.</summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginBlockStart' = MarginBlockStart.value

    let private marginBlockEndValue = FssTypes.propertyHelpers.cssValue FssTypes.Property.MarginBlockEnd
    let private marginBlockEndValue' = marginToString >> marginBlockEndValue

    [<Erase>]
    type MarginBlockEnd =
        static member value (margin: FssTypes.IMargin) = margin |> marginBlockEndValue'
        static member auto = FssTypes.Auto |> marginBlockEndValue'
        static member inherit' = FssTypes.Inherit |> marginBlockEndValue'
        static member initial = FssTypes.Initial |> marginBlockEndValue'
        static member unset = FssTypes.Unset |> marginBlockEndValue'

    /// <summary>Specifies the amount of end margin of an element </summary>
    /// <param name="margin">
    ///     can be:
    ///     - <c> Units.Size </c>
    ///     - <c> Units.Percent </c>
    ///     - <c> Inherit </c>
    ///     - <c> Initial </c>
    ///     - <c> Unset </c>
    ///     - <c> Auto </c>
    /// </param>
    /// <returns>Css property for fss.</returns>
    let MarginBlockEnd' = MarginBlockEnd.value