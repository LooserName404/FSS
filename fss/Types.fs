namespace Fss

module Types =
    // Interfaces
    type IAnimationDirection       = interface end
    type IAnimationPlayState       = interface end
    type IAnimationName            = interface end
    type IAnimationTimingFunction  = interface end
    type IAnimationFillMode        = interface end
    type IGlobal                   = interface end
    type IFont                     = interface end
    type IFontVariant              = interface end
    type IFontSize                 = interface end
    type IFontStyle                = interface end
    type IFontStretch              = interface end
    type IFontWeight               = interface end
    type ILineHeight               = interface end
    type IFontDisplay              = interface end
    type IFontFamily               = interface end
    type IFontFeatureSetting       = interface end
    type IFontVariantNumeric       = interface end
    type IFontVariantCaps          = interface end
    type IFontVariantEastAsian     = interface end
    type IFontVariantLigatures     = interface end
    type ITextAlign                = interface end
    type ITextDecorationLine       = interface end
    type ITextDecorationThickness  = interface end
    type ITextDecorationStyle      = interface end
    type ITextDecorationSkip       = interface end
    type ITextDecorationSkipInk    = interface end
    type ITextEmphasisColor        = interface end
    type ITextEmphasisPosition     = interface end
    type ITextEmphasisStyle        = interface end
    type ITextTransform            = interface end
    type ITextIndent               = interface end
    type ITextShadow               = interface end
    type ITextUnderlineOffset      = interface end
    type ITextUnderlinePosition    = interface end
    type IColor                    = interface end
    type IBorder                   = interface end
    type IBorderStyle              = interface end
    type IBorderWidth              = interface end
    type IBorderRadius             = interface end
    type IBorderColor              = interface end
    type IBorderCollapse           = interface end
    type IBorderSpacing            = interface end
    type IMargin                   = interface end
    type IPadding                  = interface end
    type IDisplay                  = interface end
    type IFlexDirection            = interface end
    type IFlexWrap                 = interface end
    type IJustifyContent           = interface end
    type IAlignItems               = interface end
    type IAlignContent             = interface end
    type IAlignSelf                = interface end
    type IOrder                    = interface end
    type IFlexGrow                 = interface end
    type IFlexShrink               = interface end
    type IFlexBasis                = interface end
    type IFlexAlignment            = interface end
    type IVerticalAlign            = interface end
    type ITransform                = interface end
    type ITransformOrigin          = interface end
    type ITime                     = interface end
    type IProperty                 = interface end
    type ITimingFunction           = interface end
    type ILinearGradient           = interface end
    type IRadialGradient           = interface end
    type IBackground               = interface end
    type IBackgroundColor          = interface end
    type IBackgroundPosition       = interface end
    type IBackgroundOrigin         = interface end
    type IBackgroundClip           = interface end
    type IBackgroundRepeat         = interface end
    type IBackgroundSize           = interface end
    type IBackgroundAttachment     = interface end
    type IBackgroundImage          = interface end
    type IContentSize              = interface end
    type ISize                     = interface end
    type IVisibility               = interface end
    type IPerspective              = interface end
    type ICursor                   = interface end
    type IContent                  = interface end
    type IRange                    = interface end
    type ISpeakAs                  = interface end
    type IListStyle                = interface end
    type IListStylePosition        = interface end
    type IListStyleImage           = interface end
    type IListStyleType            = interface end
    type IPlacement                = interface end
    type IFloat                    = interface end
    type IQuote                    = interface end
    type IOverflow                 = interface end
    type ITransition               = interface end

    // Common
    type CounterStyle = CounterStyle of string
    let counterValue (CounterStyle c) = c