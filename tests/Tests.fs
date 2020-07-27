﻿module Tests

open Fable.Core
open Fable.Mocha
open Fable.React
open Fable.React.Props
open Fable.ReactTestingLibrary

open Fss
open Html
open Global
open Property
open Fss
open Value
open Color
open Units.Size
open Units.Angle
open Fonts
open BorderStyle
open BorderWidth
open Animation
open Keyframes
open Transform
open Transition
open Display
open JustifyContent
open AlignItems
open FlexDirection
open FlexWrap
open JustifyContent
open AlignSelf
open AlignContent
open Order
open FlexGrow
open FlexShrink
open FlexBasis
open Margin
open Selector
open BackgroundImage
open LinearGradient
open RadialGradient
open BackgroundPosition
open BackgroundRepeat
open BackgroundOrigin
open BackgroundClip
open BackgroundAttachment
open ContentSize

let testCase' name case = 
    testCase name <| fun _ -> 
        use dispose = { new System.IDisposable with member this.Dispose() = RTL.cleanup() }
        case()

[<Emit("window.getComputedStyle(document.getElementById('$0'));")>]
let getComputedCssById (id : string) : obj  = jsNative

[<Emit("$0[$1];")>]
let getValue (object: obj) (key: string) : string = jsNative

let CssTests =
    testList "Css tests" [
        testCase' "Style color with named color" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "color"; ClassName (fss [ Color aliceblue]) ]
                            []

                        div 
                            [ Id "colorPink"; ClassName (fss [ BackgroundColor deeppink]) ]
                            []
                    ]
            ) |> ignore
            
            let color = getComputedCssById("color")
            let colorAlpha = getComputedCssById("colorPink")
            Expect.equal (getValue color "color") "rgb(240, 248, 255)" "named color"
            Expect.equal (getValue colorAlpha "background-color") "rgb(255, 20, 147)" "named background color"

        testCase' "Style color with RGB" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "color"; ClassName (fss [ Color (rgb 255 0 0)]) ]
                            []

                        div 
                            [ Id "colorAlpha"; ClassName (fss [ Color (rgba 255 255 255 0.5)]) ]
                            []
                    ]
            ) |> ignore
            
            let color = getComputedCssById("color")
            let colorAlpha = getComputedCssById("colorAlpha")
            Expect.equal (getValue color "color") "rgb(255, 0, 0)" "color rgb style applied"
            Expect.equal (getValue colorAlpha "color") "rgba(255, 255, 255, 0.5)" "color rgba style applied"

        testCase' "Style color with HEX" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "color"; ClassName (fss [ Color (hex "ff0000")]) ]
                            []

                        div 
                            [ Id "colorAlpha"; ClassName (fss [ Color (hex "ff000080")]) ]
                            []

                        div 
                            [ Id "colorHash"; ClassName (fss [ Color (hex "#00FF00")]) ]
                            []
                    ]
            ) |> ignore
            
            let color = getComputedCssById("color")
            let colorAlpha = getComputedCssById("colorAlpha")
            let colorHash = getComputedCssById("colorHash")
            Expect.equal (getValue color "color") "rgb(255, 0, 0)" "color hex style applied"
            Expect.equal (getValue colorAlpha "color") "rgba(255, 0, 0, 0.5)" "color hex style applied with alpha"
            Expect.equal (getValue colorHash "color") "rgb(0, 255, 0)" "color hex style applied with hash"

        testCase' "Style color with hsl" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "color"; ClassName (fss [ Color (hsl 120 1.0 0.5)]) ]
                            []

                        div 
                            [ Id "colorAlpha"; ClassName (fss [ Color (hsla 120 1.0 0.5 0.5)]) ]
                            []
                    ]
            ) |> ignore
            
            let color = getComputedCssById("color")
            let colorAlpha = getComputedCssById("colorAlpha")
            Expect.equal (getValue color "color") "rgb(0, 255, 0)" "color hsl style applied"
            Expect.equal (getValue colorAlpha "color") "rgba(0, 255, 0, 0.5)" "color hsla style applied"

        testCase' "Font-size" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "small"; ClassName (fss [ FontSize Small ]) ]
                            []

                        div 
                            [ Id "large"; ClassName (fss [ FontSize Large ]) ]
                            []


                        div 
                            [ Id "px"; ClassName (fss [ FontSize (px 100) ]) ]
                            []

                        div 
                            [ Id "pct"; ClassName (fss [ FontSize (pct 200) ]) ]
                            []
                    ]
            ) |> ignore
            
            let small = getComputedCssById("small")
            let large = getComputedCssById("large")
            let px = getComputedCssById("px")
            let pct = getComputedCssById("pct")
            Expect.equal (getValue small "font-size") "13px" "font size set to small"
            Expect.equal (getValue large "font-size") "18px" "font size set to large"
            Expect.equal (getValue px "font-size") "100px" "font size set with pixels"
            Expect.equal (getValue pct "font-size") "32px" "font size set with percent"

        
        testCase' "Borders" <| fun _ ->
            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "short"; ClassName (fss 
                                [
                                    BorderWidth Thick
                                    BorderStyle Dotted
                                    BorderColor aliceblue
                                ])]
                            []

                        div 
                            [ Id "style"; ClassName (fss [ BorderStyles [Dashed; Groove; BorderStyle.None; Dotted] ]) ]
                            []
                        div
                            [ Id "radius"; ClassName (fss [ BorderRadius (px 10)])] []
                    ]
            ) |> ignore
            
            let shortHand = getComputedCssById("short")
            let style = getComputedCssById("style")
            let radius = getComputedCssById("radius")

            Expect.equal (getValue shortHand "border-left-style") "dotted" "border style set"
            Expect.equal (getValue shortHand "border-left-color") "rgb(240, 248, 255)" "border color set"
            Expect.equal (getValue style "border-top-style") "dashed" "mixed border style"
            Expect.equal (getValue style "border-right-style") "groove" "mixed border style"
            Expect.equal (getValue style "border-bottom-style") "none" "mixed border style"
            Expect.equal (getValue style "border-left-style") "dotted" "mixed border style"
            Expect.equal (getValue radius "border-top-left-radius") "10px" "border radius"
            
        testCase' "Animations" <| fun _ ->

            let testFrames = keyframes [ frame 0 [ BackgroundColor red]; frame 100 [ BackgroundColor blue] ]
            let testFrames2 = keyframes [ frame 0 [ BackgroundColor green]; frame 100 [ BackgroundColor orangered] ]
            let shortHand = fss [ Animation [testFrames; sec 10.0; Ease; sec 200.0; Infinite; Both; AlternateReverse; Running] ]
            let longNotation = 
                fss 
                    [
                        AnimationName testFrames
                        AnimationDuration (sec 10.0)
                        AnimationTimingFunction Ease
                        AnimationDelay (sec 200.0)
                        AnimationIterationCount Infinite
                        AnimationFillMode Both
                        AnimationDirection AlternateReverse
                        AnimationPlayState Running
                    ]
            let combinedAnimations = 
                fss 
                    [ 
                        Animations 
                            [ 
                                [testFrames; sec 10.0; Ease; mSec 0.5; Infinite; Both; Alternate; Running]
                                [testFrames2; sec 1.0; Linear; sec 10.0; IterationCount.Value 3; Both; Reverse; Paused] 
                            ] 
                    ]

            RTL.render(
                fragment []
                    [
                        div [ Id "anim"; ClassName shortHand ] []    
                        div [ Id "anim2"; ClassName longNotation ] []    
                        div [ Id "anim3"; ClassName combinedAnimations ] []    
                    ]
            ) |> ignore
            
            let anim = getComputedCssById("anim")
            let anim2 = getComputedCssById("anim2")
            let anim3 = getComputedCssById("anim3")

            Expect.equal (getValue anim "animation-name") (string testFrames) "Sets animation name from shorthand"
            Expect.equal (getValue anim "animation-duration") "10s" "Sets animation duration from shorthand"
            Expect.equal (getValue anim "animation-timing-function") "ease" "Sets animation timing function from shorthand"
            Expect.equal (getValue anim "animation-delay") "200s" "Sets animation delay from shorthand"
            Expect.equal (getValue anim "animation-iteration-count") "infinite" "Sets animation iteration count from shorthand"
            Expect.equal (getValue anim "animation-fill-mode") "both" "Sets animation fillmode from shorthand"
            Expect.equal (getValue anim "animation-direction") "alternate-reverse" "Sets animation direction count from shorthand"
            Expect.equal (getValue anim "animation-play-state") "running" "Sets animation playstate from shorthand"

            Expect.equal (getValue anim2 "animation-name") (string testFrames) "Sets animation name"
            Expect.equal (getValue anim2 "animation-duration") "10s" "Sets animation duration"
            Expect.equal (getValue anim2 "animation-timing-function") "ease" "Sets animation timing function "
            Expect.equal (getValue anim2 "animation-delay") "200s" "Sets animation delay"
            Expect.equal (getValue anim2 "animation-iteration-count") "infinite" "Sets animation iteration count"
            Expect.equal (getValue anim2 "animation-fill-mode") "both" "Sets animation fillmode"
            Expect.equal (getValue anim2 "animation-direction") "alternate-reverse" "Sets animation direction count"
            Expect.equal (getValue anim2 "animation-play-state") "running" "Sets animation playstate"

            Expect.equal (getValue anim3 "animation-name") (sprintf "%A, %A" testFrames testFrames2) "Sets animation names"
            Expect.equal (getValue anim3 "animation-duration") "10s, 1s" "Sets animation durations"
            Expect.equal (getValue anim3 "animation-timing-function") "ease, linear" "Sets animation timing functions"
            Expect.equal (getValue anim3 "animation-delay") "0.0005s, 10s" "Sets animation delays"
            Expect.equal (getValue anim3 "animation-iteration-count") "infinite, 3" "Sets animation iteration counts"
            Expect.equal (getValue anim3 "animation-fill-mode") "both, both" "Sets animation fillmodes"
            Expect.equal (getValue anim3 "animation-direction") "alternate, reverse" "Sets animation direction counts"
            Expect.equal (getValue anim3 "animation-play-state") "running, paused" "Sets animation playstates"

        testCase' "Style width and height" <| fun _ ->         
            RTL.render(
                div [ ClassName (fss [ Width (px 200); Height (px 200)] ) ]
                    [
                        div 
                            [ Id "size"; ClassName (fss [ Width (px 1000); Height (px 500); MinHeight (px 20); MaxHeight (px 50); MinWidth (px 50); MaxWidth (px 100) ]) ]
                            []

                        div 
                            [ Id "content"; ClassName (fss [Width MaxContent; Height MinContent; MinHeight (FitContent (px 20))]) ]
                            []
                    ]
            ) |> ignore
                
            let contentSize = getComputedCssById("size")
            Expect.equal (getValue contentSize "width") "100px" "width gets set"
            Expect.equal (getValue contentSize "height") "50px" "height gets set"

            Expect.equal (getValue contentSize "min-width") "50px" "min-width gets set"
            Expect.equal (getValue contentSize "min-height") "20px" "min-height gets set"

            Expect.equal (getValue contentSize "max-width") "100px" "max-width gets set"
            Expect.equal (getValue contentSize "max-height") "50px" "max-height gets set"

            let contentTest = getComputedCssById("content")
            Expect.equal (getValue contentTest "width") "0px" "width gets set to max content"
            Expect.equal (getValue contentTest "height") "0px" "height gets set to min content"
            Expect.equal (getValue contentTest "min-height") "0px" "min-height gets set to fit content"


        testCase' "Set global values" <| fun _ ->
            let style = 
                fss
                    [
                        Color Inherit
                        BackgroundColor Initial
                    ]

            RTL.render(
                fragment []
                    [
                        div 
                            [ Id "globals"; ClassName style ]
                            []
                    ]
            ) |> ignore
                
            let globals = getComputedCssById("globals")
            Expect.equal (getValue globals "color") "rgb(0, 0, 0)" "Inherit set"
            Expect.equal (getValue globals "background-color") "rgba(0, 0, 0, 0)" "Initial set"

        testCase' "Set margin" <| fun _ ->
            let shortShortHand = 
                fss
                    [
                        CSSProperty.Margin (px 10)
                    ]

            let shortHand =
                fss
                    [
                        Margins [px 10; px 20; px 30; px 40]
                    ]

            let margin =
                fss
                    [
                        MarginTop (px 30)
                        MarginRight (px 20)
                        MarginBottom (px 40)
                        MarginLeft (px 10)
                    ]

            RTL.render(
                fragment []
                    [
                        div [ Id "shortShortHand"; ClassName shortShortHand ] []
                        div [ Id "shortHand"; ClassName shortHand ] []
                        div [ Id "margins"; ClassName margin ] []
                    ]
            ) |> ignore
                
            let shortShortHand = getComputedCssById("shortShortHand")
            Expect.equal (getValue shortShortHand "margin-top") "10px" "Margin top gets set"
            Expect.equal (getValue shortShortHand "margin-right") "10px" "Margin top gets set"
            Expect.equal (getValue shortShortHand "margin-bottom") "10px" "Margin top gets set"
            Expect.equal (getValue shortShortHand "margin-left") "10px" "Margin top gets set"

            let shortHand = getComputedCssById("shortHand")
            Expect.equal (getValue shortHand "margin-top") "10px" "Margin top gets set shorthand"
            Expect.equal (getValue shortHand "margin-right") "20px" "Margin top gets set shorthand"
            Expect.equal (getValue shortHand "margin-bottom") "30px" "Margin top gets set shorthand"
            Expect.equal (getValue shortHand "margin-left") "40px" "Margin top gets set shorthand"

            let margin = getComputedCssById("margins")
            Expect.equal (getValue margin "margin-top") "30px" "Margin top gets set margins"
            Expect.equal (getValue margin "margin-right") "20px" "Margin top gets set margins"
            Expect.equal (getValue margin "margin-bottom") "40px" "Margin top gets set margins"
            Expect.equal (getValue margin "margin-left") "10px" "Margin top gets set margins"
            
        testCase' "Set padding" <| fun _ ->
            let shortShortHand = 
                fss
                    [
                        CSSProperty.Padding (px 10)
                    ]

            let shortHand =
                fss
                    [
                        Paddings [px 10; px 20; px 30; px 40]
                    ]

            let padding =
                fss
                    [
                        PaddingTop (px 30)
                        PaddingRight (px 20)
                        PaddingBottom (px 40)
                        PaddingLeft (px 10)
                    ]

            RTL.render(
                fragment []
                    [
                        div [ Id "shortShortHand"; ClassName shortShortHand ] []
                        div [ Id "shortHand"; ClassName shortHand ] []
                        div [ Id "paddings"; ClassName padding ] []
                    ]
            ) |> ignore
                    
            let shortShortHand = getComputedCssById("shortShortHand")
            Expect.equal (getValue shortShortHand "padding-top") "10px" "Padding top gets set"
            Expect.equal (getValue shortShortHand "padding-right") "10px" "Padding top gets set"
            Expect.equal (getValue shortShortHand "padding-bottom") "10px" "Padding top gets set"
            Expect.equal (getValue shortShortHand "padding-left") "10px" "Padding top gets set"

            let shortHand = getComputedCssById("shortHand")
            Expect.equal (getValue shortHand "padding-top") "10px" "Padding top gets set shorthand"
            Expect.equal (getValue shortHand "padding-right") "20px" "Padding top gets set shorthand"
            Expect.equal (getValue shortHand "padding-bottom") "30px" "Padding top gets set shorthand"
            Expect.equal (getValue shortHand "padding-left") "40px" "Padding top gets set shorthand"

            let padding = getComputedCssById("paddings")
            Expect.equal (getValue padding "padding-top") "30px" "Padding top gets set paddings"
            Expect.equal (getValue padding "padding-right") "20px" "Padding top gets set paddings"
            Expect.equal (getValue padding "padding-bottom") "40px" "Padding top gets set paddings"
            Expect.equal (getValue padding "padding-left") "10px" "Padding top gets set paddings"


        testCase' "Flexbox tests" <| fun _ ->
            let flex =
                fss
                    [
                        Display Display.Flex
                        CSSProperty.FlexBasis (px 120)
                        FlexDirection Column
                        FlexWrap FlexWrap.Wrap
                        FlexGrow (Grow 1)
                        FlexShrink (Shrink 1)
                        JustifyContent JustifyContent.SpaceAround
                        AlignContent AlignContent.Center
                        AlignItems AlignItems.Center

                    ]

            RTL.render(
                fragment []
                    [
                        div [ Id "flex"; ClassName flex ] []
                    ]
            ) |> ignore
                    
            let flex = getComputedCssById("flex")
            Expect.equal (getValue flex "display") "flex" "Display gets set"
            Expect.equal (getValue flex "flex-direction") "column" "flex direction gets set"
            Expect.equal (getValue flex "flex-wrap") "wrap" "flex wrap gets set"
            Expect.equal (getValue flex "flex-grow") "1" "flex grow gets set"
            Expect.equal (getValue flex "flex-shrink") "1" "flex shrink gets set"
            Expect.equal (getValue flex "flex-basis") "120px" "flex basis gets set"
            Expect.equal (getValue flex "justify-content") "space-around" "justify content gets set"
            Expect.equal (getValue flex "align-content") "center" "align content gets set"
            Expect.equal (getValue flex "align-items") "center" "align items gets set"
            
        testCase' "Style descendant" <| fun _ ->
            let style =
                fss
                    [
                       Selector ((Descendant Div), [ BackgroundColor red ])
                    ]
            
            RTL.render(
                div [ ClassName style ]
                    [
                        div [ Id "foo" ] [ str "foo" ]
                    ]
            ) |> ignore
                    
            let style = getComputedCssById("foo")
            Expect.equal (getValue style "background-color") "rgb(255, 0, 0)" "Descendant gets background color"

        testCase' "Transforms" <| fun _ ->
                let style1 =
                    fss
                        [
                            Width (px 50)
                            Height (px 50)
                            BackgroundColor red
                            Transform (Skew2(deg 30.0, deg 20.0))
                        ]

                let style2 =
                    fss
                        [
                            Width (px 50)
                            Height (px 50)
                            BackgroundColor red
                            Transform (Matrix(1.0, 2.0, 3.0, 4.0, 5.0, 6.0))
                        ]
                 
                RTL.render(
                    fragment [ ]
                        [
                            div [ Id "one"; ClassName style1 ] []
                            div [ Id "two"; ClassName style2 ] []
                        ]
                ) |> ignore
                         
                let style1 = getComputedCssById("one")
                let style2 = getComputedCssById("two")
                Expect.equal (getValue style1 "transform") "matrix(1, 0.36397, 0.57735, 1, 0, 0)" "Transform gets set by skew"
                Expect.equal (getValue style2 "transform") "matrix(1, 2, 3, 4, 5, 6)" "Transform gets set by matrix"

        testCase' "Transitions" <| fun _ ->
            let oneTransition =
                fss
                    [
                       Transition (Transition1(backgroundColor, (sec 10.0)))
                    ]

            let manyTransitions =
                fss
                    [
                       Transitions 
                        [
                            Transition1(backgroundColor, (sec 10.0))
                            Transition2(color, (sec 20.0), EaseInOut)
                            Transition3(width, (sec 30.0), EaseOut, (sec 20.0))
                        ]
                    ]
            
            RTL.render(
                fragment []
                    [
                        div [ Id "one"; ClassName oneTransition ] []
                        div [ Id "two"; ClassName manyTransitions ] []
                    ]
            ) |> ignore
                    
            let one = getComputedCssById("one")
            let two = getComputedCssById("two")

            Expect.equal (getValue one "transition-property") "background-color" "Background color is the transition property"
            Expect.equal (getValue one "transition-duration") "10s" "transition duration is 10 sec"

            Expect.equal (getValue two "transition-property") "background-color, color, width" "transition properties for multiple transitions set"
            Expect.equal (getValue two "transition-duration") "10s, 20s, 30s" "transition duration for multiple transitions set"
            Expect.equal (getValue two "transition-timing-function") "ease, ease-in-out, ease-out" "transition timing function set"
            Expect.equal (getValue two "transition-delay") "0s, 0s, 20s" "transition delay set"

        testCase' "Background" <| fun _ ->
            let linear1 = fss [ BackgroundImage (LinearGradient [ red; blue ] ) ]
            let linear2 = fss [ BackgroundImage (LinearGradient [ Right; red; blue ] ) ]
            let linear3 = fss [ BackgroundImage (LinearGradient [ Bottom; red; blue ] ) ]
            let linear4 = fss [ BackgroundImage (LinearGradient [ deg 72.0; red; blue ] ) ]
            let radial1 = fss [ BackgroundImage (RadialGradient [ CircleAt [pct 100]; hex "333"; hex "333"; pct 50; hex "eee"; pct 75; hex "333"; pct 75] ) ]
            let backgroundPosition = fss [ BackgroundPosition (px 10)]
            let backgroundPositions = fss [ BackgroundPositions [px 10; Bottom]]
            let backgroundRepeat = fss [ BackgroundRepeat RepeatX ]
            let backgroundRepeats = fss [ BackgroundRepeats [Repeat; Space] ]
            let backgroundOrigin = fss [ BackgroundOrigin BorderBox]
            let backgroundClip = fss [ BackgroundClip BorderBox]
            let backgroundAttachment = fss [ BackgroundAttachment Scroll]

            RTL.render(
                div [ ]
                    [
                        div [ Id "1"; ClassName linear1 ] [ ]
                        div [ Id "2"; ClassName linear2 ] [ ]
                        div [ Id "3"; ClassName linear3 ] [ ]
                        div [ Id "4"; ClassName linear4 ] [ ]
                        div [ Id "5"; ClassName radial1 ] [ ]
                        div [ Id "6"; ClassName backgroundPosition ] [ ]
                        div [ Id "7"; ClassName backgroundPositions ] [ ]
                        div [ Id "8"; ClassName backgroundRepeat ] [ ]
                        div [ Id "9"; ClassName backgroundRepeats ] [ ]
                        div [ Id "10"; ClassName backgroundOrigin ] [ ]
                        div [ Id "11"; ClassName backgroundClip ] [ ]
                        div [ Id "12"; ClassName backgroundAttachment ] [ ]
                    ]
            ) |> ignore
                    
            let one = getComputedCssById("1")
            let two = getComputedCssById("2")
            let three = getComputedCssById("3")
            let four = getComputedCssById("4")
            let five = getComputedCssById("5")
            let six = getComputedCssById("6")
            let seven = getComputedCssById("7")
            let eight = getComputedCssById("8")
            let nine = getComputedCssById("9")
            let ten = getComputedCssById("10")
            let eleven = getComputedCssById("11")
            let twelve = getComputedCssById("12")

            Expect.equal (getValue one "background-image") "linear-gradient(rgb(255, 0, 0), rgb(0, 0, 255))" "Linear gradient set with two colors"
            Expect.equal (getValue two "background-image") "linear-gradient(to right, rgb(255, 0, 0), rgb(0, 0, 255))" "Linear gradient set with two colors with direction"
            Expect.equal (getValue three "background-image") "linear-gradient(rgb(255, 0, 0), rgb(0, 0, 255))" "Linear gradient set with two rgb"
            Expect.equal (getValue four "background-image") "linear-gradient(72deg, rgb(255, 0, 0), rgb(0, 0, 255))" "Linear gradient set with degrees"
            Expect.equal (getValue five "background-image") "radial-gradient(circle at 100% 50%, rgb(51, 51, 51), rgb(51, 51, 51) 50%, rgb(238, 238, 238) 75%, rgb(51, 51, 51) 75%)" "Radial gradient with shape and side"

            Expect.equal (getValue six "background-position") "10px 50%" "Set one background position"
            Expect.equal (getValue seven "background-position") "10px 100%" "Set several background positions"

            Expect.equal (getValue eight "background-repeat") "repeat-x" "Set one background repeat"
            Expect.equal (getValue nine "background-repeat") "repeat space" "Set several background repeats"

            Expect.equal (getValue ten "background-origin") "border-box" "Set background origin"

            Expect.equal (getValue eleven "background-clip") "border-box" "Set background clip"

            Expect.equal (getValue twelve "background-attachment") "scroll" "Set background attachment"
    ]

Mocha.runTests CssTests |> ignore





