namespace Fss

open Fss.Utilities.Helpers

module Global =
    open Types

    type None =
        | None
        interface IFontVariantLigatures
        interface IBorderStyle
        interface IPerspective
        interface IDisplay
        interface IAnimationFillMode
        interface ITransform
        interface ITextTransform
        interface ITextDecorationLine
        interface ITextDecorationSkip
        interface ITextDecorationSkipInk
        interface ITextEmphasisStyle
        
    type Auto =
        | Auto
        interface IContentSize
        interface IFlexBasis
        interface IAlignSelf
        interface IMargin
        interface IPadding
        interface ITextDecorationThickness
        interface ITextDecorationSkipInk
        interface IBackgroundSize
        interface ITextUnderlineOffset
        interface ITextUnderlinePosition
        
    type Center =
        | Center
        interface IAlignSelf
        interface IAlignItems
        interface IAlignContent
        interface IJustifyContent

    type Normal =
        | Normal
        interface IFontStyle
        interface IFontWeight

    type Global =
        | Initial
        | Inherit
        | Unset
        | Revert
        interface IGlobal
        interface IFontSize
        interface IFontStretch
        interface IFontStyle
        interface IFontWeight
        interface ILineHeight
        interface IFontFamily
        interface IFontFeatureSetting
        interface IFontVariantNumeric
        interface IFontVariantCaps
        interface IFontVariantEastAsian
        interface IFontVariantLigatures
        interface ITextAlign
        interface ITextDecorationLine
        interface ITextDecorationThickness
        interface ITextDecorationStyle
        interface ITextDecorationSkip
        interface ITextDecorationSkipInk
        interface ITextTransform
        interface ITextEmphasisColor
        interface ITextEmphasisPosition
        interface ITextEmphasisStyle
        interface ITextIndent
        interface ITextShadow
        interface ITextUnderlineOffset
        interface ITextUnderlinePosition
        interface IColor
        interface IBorderStyle
        interface IBorderWidth
        interface IBorderRadius
        interface IBorderColor
        interface IMargin
        interface IPadding
        interface IDisplay
        interface IFlexDirection
        interface IFlexWrap
        interface IJustifyContent
        interface IAlignItems
        interface IAlignContent
        interface IAlignSelf
        interface IOrder
        interface IFlexGrow
        interface IFlexShrink
        interface IFlexBasis
        interface IVerticalAlign
        interface ITransform
        interface ITransformOrigin
        interface ITransitionTime
        interface ITransitionProperty
        interface ITransitionTimingFunction
        interface IBackgroundPosition
        interface IBackgroundOrigin
        interface IBackgroundClip
        interface IBackgroundRepeat
        interface IBackgroundSize
        interface IBackgroundAttachment
        interface IContentSize
        interface IVisibility
        interface IAnimationDirection
        interface IAnimationPlayState
        interface IAnimationName
        interface IAnimationTimingFunction
        interface IPerspective

module GlobalValue =
    open Global

    let globalValue (v: Global): string = duToLowercase v
    let none (v: None): string = duToLowercase v
    let normal (v: Normal): string = duToLowercase v
    let center (v: Center): string = duToLowercase v
    let auto (v: Auto): string = duToLowercase v