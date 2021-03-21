namespace Fss

open System
open Fable.Core
open Fable.Core.JsInterop

open Media
open Keyframes
open FssTypes

[<AutoOpen>]
module Functions =
    [<Import("css", from="@emotion/css")>]
    let private css(x) = jsNative
    let css' x = css(x)

    // Constructors
    let private fssObject (attributeList: CssProperty list) =
        attributeList
        |> List.map GlobalValue.CssValue
        |> createObj
        |> css'

    let fss (attributeList: CssProperty list) =
        attributeList
        |> fssObject
        |> string

    // Keyframes
    let keyframes (attributeList: KeyframeAttribute list) =
        attributeList
        |> createAnimationObject
        |> keyframes'
        |> CssString
        :> IAnimationName

    /// <summary>Write Css as key value string pairs.
    /// Allows you to add values not supported by Fss.</summary>
    /// <param name="key">Css property</param>
    /// <param name="value">Css value </param>
    /// <returns>Css property for fss.</returns>
    let Custom (key: string) (value: string) = key ==> value |> CssProperty

    let frame (f: int) (properties: CssProperty list) = (f, properties) |> Keyframes.Frame
    let frames (f: int list) (properties: CssProperty list) = (f, properties) |> Keyframes.Frames

    let counterStyle (attributeList: CounterProperty list) =
        let counterName = sprintf "counter_%s" <| Guid.NewGuid().ToString()

        createCounterObject attributeList counterName |> css' |> ignore

        counterName |> CounterStyle

    // Media
    let MediaQueryFor (device: Device) (features: MediaFeature list) (attributeList: CssProperty list) =
        Media.Media(device, features, attributeList)
    let MediaQuery (features: MediaFeature list) (attributeList: CssProperty list) =
        Media.Media(features, attributeList)

    // Font
    let fontFace (fontFamily: string) (attributeList: CssProperty list) =
        attributeList
        |> createFontFaceObject fontFamily
        |> css'
        Types.FontName fontFamily

    let fontFaces (fontFamily: string) (attributeLists: CssProperty list list) =
        attributeLists
        |> List.map (createFontFaceObject fontFamily)
        |> css'

        Types.FontName fontFamily

    // Color
    let rgb (r: int) (g: int) (b: int) = Types.Color.Rgb(r,g,b)
    let rgba (r: int) (g: int) (b: int) (a: float) = Types.Color.Rgba(r,g,b,a)

    let hex (value: string) = Types.Color.Hex value

    let hsl (h: int) (s: float) (l: float) = Types.Color.Hsl(h,s,l)
    let hsla (h: int) (s: float) (l: float) (a: float) = Types.Color.Hsla(h,s,l,a)

    // Sizes
    // Absolute
    let px (v: int): Types.Size = sprintf "%dpx" v |> Units.Size.Px
    let inc (v: float): Types.Size = sprintf "%.1fin" v |> Units.Size.In
    let cm (v: float): Types.Size = sprintf "%.1fcm" v |> Units.Size.Cm
    let mm (v: float): Types.Size = sprintf "%.1fmm" v |> Units.Size.Mm
    let pt (v: float): Types.Size = sprintf "%.1fpt" v |> Units.Size.Pt
    let pc (v: float): Types.Size = sprintf "%.1fpc" v |> Units.Size.Pc

    // Relative
    let em (v: float): Types.Size = sprintf "%.1fem" v |> Units.Size.Em
    let rem (v: float): Types.Size = sprintf "%.1frem" v |> Units.Size.Rem
    let ex (v: float): Types.Size = sprintf "%.1fex" v |> Units.Size.Ex
    let ch (v: float): Types.Size = sprintf "%.1fch" v |> Units.Size.Ch
    let vw (v: float): Types.Size = sprintf "%.1fvw" v |> Units.Size.Vw
    let vh (v: float): Types.Size = sprintf "%.1fvh" v |> Units.Size.Vh
    let vmax (v: float): Types.Size = sprintf "%.1fvmax" v |> Units.Size.VMax
    let vmin (v: float): Types.Size = sprintf "%.1fvmin" v |> Units.Size.VMin

    // Angles
    let deg (v: float): Types.Angle = sprintf "%.2fdeg" v |> Units.Angle.Deg
    let grad (v: float): Types.Angle = sprintf "%.2fgrad" v |> Units.Angle.Grad
    let rad (v: float): Types.Angle = sprintf "%.4frad" v |> Units.Angle.Rad
    let turn (v: float): Types.Angle = sprintf "%.2fturn" v |> Units.Angle.Turn

    // Percent
    let pct (v: int): Types.Percent = sprintf "%d%%" v |> Types.Percent

    // Time
    let sec (v: float): Types.Time = sprintf "%.2fs" v |> Units.Time.Sec
    let ms (v: float): Types.Time = sprintf "%.2fms" v |> Units.Time.Ms

    // Fractions
    let fr (v: float): Units.Fraction.Fraction = sprintf "%.2ffr" v |> Units.Fraction.Fr