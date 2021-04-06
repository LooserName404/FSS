namespace Fss
namespace Fss.FssTypes
    open Fable.Core.JsInterop
    [<RequireQualifiedAccess>]
    module Property =
        type Property =
            | Appearance
            | AlignContent
            | AlignItems
            | AlignSelf
            | All
            | AnimationDelay
            | AnimationDirection
            | AnimationDuration
            | AnimationFillMode
            | AnimationIterationCount
            | AnimationName
            | AnimationPlayState
            | AnimationTimingFunction
            | AspectRatio
            | BackfaceVisibility
            | BackgroundAttachment
            | BackgroundBlendMode
            | BackgroundClip
            | BackgroundColor
            | BackgroundImage
            | BackgroundOrigin
            | BackgroundPosition
            | BackgroundRepeat
            | BackgroundSize
            | BackdropFilter
            | Bleed
            | Border
            | BorderBottomColor
            | BorderBottomLeftRadius
            | BorderBottomRightRadius
            | BorderBottomStyle
            | BorderBottomWidth
            | BorderBottom
            | BorderCollapse
            | BorderColor
            | BorderImage
            | BorderImageOutset
            | BorderImageRepeat
            | BorderImageSource
            | BorderImageSlice
            | BorderImageWidth
            | BorderLeftColor
            | BorderLeftStyle
            | BorderLeftWidth
            | BorderLeft
            | BorderRadius
            | BorderRightColor
            | BorderRightStyle
            | BorderRightWidth
            | BorderRight
            | BorderSpacing
            | BorderStyle
            | BorderTopColor
            | BorderTopLeftRadius
            | BorderTopRightRadius
            | BorderTopStyle
            | BorderTopWidth
            | BorderTop
            | BorderWidth
            | BorderBlockColor
            | Bottom
            | BoxDecorationBreak
            | BoxShadow
            | BoxSizing
            | BreakAfter
            | BreakBefore
            | BreakInside
            | CaptionSide
            | CaretColor
            | Clear
            | Clip
            | ClipPath
            | Color
            | ColorAdjust
            | Columns
            | ColumnCount
            | ColumnFill
            | ColumnGap
            | ColumnRule
            | ColumnRuleColor
            | ColumnRuleStyle
            | ColumnRuleWidth
            | ColumnSpan
            | ColumnWidth
            | Content
            | CounterIncrement
            | CounterReset
            | CueAfter
            | CueBefore
            | Cue
            | Cursor
            | Direction
            | Display
            | Elevation
            | EmptyCells
            | Filter
            | Flex
            | FlexBasis
            | FlexDirection
            | FontFeatureSettings
            | FlexFlow
            | FlexGrow
            | FlexShrink
            | FlexWrap
            | Float
            | FontFamily
            | FontKerning
            | FontLanguageOverride
            | FontSizeAdjust
            | FontSize
            | FontStretch
            | FontStyle
            | FontDisplay
            | FontSynthesis
            | FontVariant
            | FontVariantAlternates
            | FontVariantCaps
            | FontVariantEastAsian
            | FontVariantLigatures
            | FontVariantNumeric
            | FontVariantPosition
            | FontWeight
            | Font
            | GridArea
            | GridAutoColumns
            | GridAutoFlow
            | GridAutoRows
            | GridColumnEnd
            | GridColumnStart
            | GridColumn
            | GridGap
            | GridRowEnd
            | GridRowGap
            | GridColumnGap
            | GridRowStart
            | GridRow
            | GridTemplateAreas
            | GridTemplateColumns
            | GridTemplateRows
            | GridTemplate
            | Grid
            | HangingPunctuation
            | Height
            | Hyphens
            | Isolation
            | JustifyContent
            | JustifyItems
            | JustifySelf
            | Label
            | Left
            | LetterSpacing
            | LineBreak
            | LineHeight
            | ListStyle
            | ListStyleImage
            | ListStylePosition
            | ListStyleType
            | MaskClip
            | MaskComposite
            | MaskImage
            | MaskMode
            | MaskOrigin
            | MaskPosition
            | MaskRepeat
            | MaskSize
            | MarginBottom
            | MarginLeft
            | MarginRight
            | MarginTop
            | Margin
            | MarginInlineStart
            | MarginInlineEnd
            | MarginBlockStart
            | MarginBlockEnd
            | MarkerOffset
            | Marks
            | MaxHeight
            | MaxWidth
            | MinHeight
            | MinWidth
            | MixBlendMode
            | NavUp
            | NavDown
            | NavLeft
            | NavRight
            | Opacity
            | Order
            | Orphans
            | OutlineColor
            | OutlineOffset
            | OutlineStyle
            | OutlineWidth
            | Outline
            | Overflow
            | OverflowWrap
            | OverflowX
            | OverflowY
            | ObjectFit
            | ObjectPosition
            | PaddingBottom
            | PaddingLeft
            | PaddingRight
            | PaddingTop
            | Padding
            | PaddingInlineStart
            | PaddingInlineEnd
            | PaddingBlockStart
            | PaddingBlockEnd
            | Page
            | PauseAfter
            | PauseBefore
            | Pause
            | PaintOrder
            | PointerEvents
            | Perspective
            | PerspectiveOrigin
            | PitchRange
            | Pitch
            | PlaceContent
            | PlaceItems
            | PlaceSelf
            | PlayDuring
            | Position
            | Quotes
            | Resize
            | RestAfter
            | RestBefore
            | Rest
            | Richness
            | Right
            | Size
            | SpeakHeader
            | SpeakNumeral
            | SpeakPunctuation
            | Src
            | Speak
            | SpeechRate
            | Stress
            | ScrollBehavior
            | ScrollMarginBottom
            | ScrollMarginLeft
            | ScrollMarginRight
            | ScrollMarginTop
            | ScrollMargin
            | ScrollPaddingBottom
            | ScrollPaddingLeft
            | ScrollPaddingRight
            | ScrollPaddingTop
            | ScrollPadding
            | OverscrollBehaviorX
            | OverscrollBehaviorY
            | TabSize
            | TableLayout
            | TextAlign
            | TextAlignLast
            | TextDecoration
            | TextDecorationColor
            | TextDecorationLine
            | TextDecorationThickness
            | TextDecorationSkip
            | TextDecorationSkipInk
            | TextDecorationStyle
            | TextIndent
            | TextOverflow
            | TextShadow
            | TextTransform
            | TextEmphasis
            | TextEmphasisColor
            | TextEmphasisPosition
            | TextEmphasisStyle
            | TextUnderlineOffset
            | TextUnderlinePosition
            | TextSizeAdjust
            | TextOrientation
            | TextRendering
            | TextJustify
            | Top
            | Transform
            | TransformOrigin
            | TransformStyle
            | Transition
            | TransitionDelay
            | TransitionDuration
            | TransitionProperty
            | TransitionTimingFunction
            | UnicodeBidi
            | UserSelect
            | VerticalAlign
            | Visibility
            | VoiceBalance
            | VoiceDuration
            | VoiceFamily
            | VoicePitch
            | VoiceRange
            | VoiceRate
            | VoiceStress
            | VoiceVolume
            | Volume
            | WhiteSpace
            | Widows
            | Width
            | WillChange
            | WordBreak
            | WordSpacing
            | WordWrap
            | WritingMode
            | ZIndex

            | Active
            | AnyLink
            | Blank
            | Checked
            | Current
            | Disabled
            | Empty
            | Enabled
            | FirstChild
            | FirstOfType
            | Focus
            | FocusVisible
            | FocusWithin
            | Future
            | Hover
            | Indeterminate
            | Invalid
            | InRange
            | Lang
            | LastChild
            | LastOfType
            | Link
            | LocalLink
            | NthChild
            | NthLastChild
            | NthLastOfType
            | NthOfType
            | OnlyChild
            | OnlyOfType
            | Optional
            | OutOfRange
            | Past
            | Playing
            | Paused
            | PlaceholderShown
            | ReadOnly
            | ReadWrite
            | Required
            | Root
            | Scope
            | Target
            | TargetWithin
            | Valid
            | Visited
            | UserInvalid

            | After
            | Before
            | FirstLetter
            | FirstLine
            | Selection
            interface ITransitionProperty

    [<AutoOpen>]
    module propertyHelpers =
        let internal propertyToString (v: Property.Property): string = Fss.Utilities.Helpers.duToCamel v

        let internal toKebabCase (property: Property.Property): string =
            property
            |> propertyToString
            |> Fss.Utilities.Helpers.pascalToKebabCase

        let internal cssValue (property: Property.Property) cssValue =
            property |> propertyToString ==> cssValue |> CssProperty

