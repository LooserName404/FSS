namespace Fss

open Value
open Selector
open Media
open Html
open Units.Size
open Color
open FontFace
open Keyframes

[<AutoOpen>]
module Functions =
    // Constructors
    let fss (attributeList: CSSProperty list) = 
        attributeList |> createCSSObject |> css'

    let keyframes (attributeList: KeyframeAttribute list) = 
        attributeList |> createAnimationObject |> kframes'

    let fontFace (fontFamily: string) (attributeList: FontFace list) =
        attributeList |> createFontFaceObject fontFamily |> css'
        FontName fontFamily

    // Media
    let Media (r: MediaFeature list) (p: CSSProperty list) = Media(r, p)
    let MediaFor (d: Device) (r: MediaFeature list) (p: CSSProperty list) = MediaFor(d, r, p)

    // Text shadow
    let TextShadows (textShadows: (Size * Size * Size * CssColor) list): CSSProperty =
        textShadows
        |> List.map (
            (fun (x, y, b, c) -> TextShadow.TextShadow(x, y, b, c)) >>
            (fun x -> x :> Types.ITextShadow))
        |> TextShadows

    let TextShadow (x: Size) (y: Size) (blur: Size) (color: CssColor): CSSProperty = 
        TextShadow (TextShadow.TextShadow(x, y, blur, color))

    // Selectors
    let (!+) (html: Html) (propertyList: CSSProperty list) = Selector (AdjacentSibling html, propertyList)
    let (!~) (html: Html) (propertyList: CSSProperty list) = Selector (GeneralSibling html, propertyList)
    let (!>) (html: Html) (propertyList: CSSProperty list) = Selector (Child html, propertyList)
    let (! ) (html: Html) (propertyList: CSSProperty list) = Selector (Descendant html, propertyList)

    // Global
    let Initial = Global.Initial
    let Inherit = Global.Inherit
    let Unset = Global.Unset 
    let Revert = Global.Revert

    // Color
    let rgb (r: int) (g: int) (b: int): CssColor = Utilities.Color.rgb r g b |> CssColor
    let rgba (r: int) (g: int) (b: int) (a: float): CssColor = Utilities.Color.rgba r g b a |> CssColor

    let hex (value: string): CssColor = Utilities.Color.hex value |> CssColor

    let hsl (h: int) (s: float) (l: float): CssColor = Utilities.Color.hsl h s l |> CssColor
    let hsla (h: int) (s: float) (l: float) (a: float):CssColor = Utilities.Color.hsla h s l a |> CssColor

    let black = hex "000000"
    let silver = hex "c0c0c0"
    let gray = hex "808080"
    let white = hex "ffffff"
    let maroon = hex "800000"
    let red = hex "ff0000"
    let purple = hex "800080"
    let fuchsia = hex "ff00ff"
    let green = hex "008000"
    let lime = hex "00ff00"
    let olive = hex "808000"
    let yellow = hex "ffff00"
    let navy = hex "000080"
    let blue = hex "0000ff"
    let teal = hex "008080"
    let aqua = hex "00ffff"
    let orange = hex "ffa500"
    let aliceBlue = hex "f0f8ff"
    let antiqueWhite = hex "faebd7"
    let aquaMarine = hex "7fffd4"
    let azure = hex "f0ffff"
    let beige = hex "f5f5dc"
    let bisque = hex "ffe4c4"
    let blanchedAlmond = hex "ffebcd"
    let blueViolet = hex "8a2be2"
    let brown = hex "a52a2a"
    let burlywood = hex "deb887"
    let cadetBlue = hex "5f9ea0"
    let chartreuse = hex "7fff00"
    let chocolate = hex "d2691e"
    let coral = hex "ff7f50"
    let cornflowerBlue = hex "6495ed"
    let cornsilk = hex "fff8dc"
    let crimson = hex "dc143c"
    let cyan = hex "00ffff"
    let darkBlue = hex "00008b"
    let darkCyan = hex "008b8b"
    let darkGoldenrod = hex "b8860b"
    let darkGray = hex "a9a9a9"
    let darkGreen = hex "006400"
    let darkKhaki = hex "bdb76b"
    let darkMagenta = hex "8b008b"
    let darkOliveGreen = hex "556b2f"
    let darkOrange = hex "ff8c00"
    let darkOrchid = hex "9932cc"
    let darkRed = hex "8b0000"
    let darkSalmon = hex "e9967a"
    let darkSeaGreen = hex "8fbc8f"
    let darkSlateBlue = hex "483d8b"
    let darkSlateGray = hex "2f4f4f"
    let darkTurquoise = hex "00ced1"
    let darkViolet = hex "9400d3"
    let deepPink = hex "ff1493"
    let deepSkyBlue = hex "00bfff"
    let dimGrey = hex "696969"
    let dodgerBlue = hex "1e90ff"
    let fireBrick = hex "b22222"
    let floralWhite = hex "fffaf0"
    let forestGreen = hex "228b22"
    let gainsboro = hex "dcdcdc"
    let ghostWhite = hex "f8f8ff"
    let gold = hex "ffd700"
    let goldenrod = hex "daa520"
    let greenYellow = hex "adff2f"
    let grey = hex "808080"
    let honeydew = hex "f0fff0"
    let hotPink = hex "ff69b4"
    let indianRed = hex "cd5c5c"
    let indigo = hex "4b0082"
    let ivory = hex "fffff0"
    let khaki = hex "f0e68c"
    let lavender = hex "e6e6fa"
    let lavenderBlush = hex "fff0f5"
    let lawnGreen = hex "7cfc00"
    let lemonChiffon = hex "fffacd"
    let lightBlue = hex "add8e6"
    let lightCoral = hex "f08080"
    let lightCyan = hex "e0ffff"
    let lightGoldenrodYellow = hex "fafad2"
    let lightGray = hex "d3d3d3"
    let lightGreen = hex "90ee90"
    let lightGrey = hex "d3d3d3"
    let lightPink = hex "ffb6c1"
    let lightSalmon = hex "ffa07a"
    let lightSeaGreen = hex "20b2aa"
    let lightSkyBlue = hex "87cefa"
    let lightSlateGrey = hex "778899"
    let lightSteelBlue = hex "b0c4de"
    let lightYellow = hex "ffffe0"
    let limeGreen = hex "32cd32"
    let linen = hex "faf0e6"
    let magenta = hex "ff00ff"
    let mediumAquamarine = hex "66cdaa"
    let mediumBlue = hex "0000cd"
    let mediumOrchid = hex "ba55d3"
    let mediumPurple = hex "9370db"
    let mediumSeaGreen = hex "3cb371"
    let mediumSlateBlue = hex "7b68ee"
    let mediumSpringGreen = hex "00fa9a"
    let mediumTurquoise = hex "48d1cc"
    let mediumVioletRed = hex "c71585"
    let midnightBlue = hex "191970"
    let mintCream = hex "f5fffa"
    let mistyRose = hex "ffe4e1"
    let moccasin = hex "ffe4b5"
    let navajoWhite = hex "ffdead"
    let oldLace = hex "fdf5e6"
    let olivedrab = hex "6b8e23"
    let orangeRed = hex "ff4500"
    let orchid = hex "da70d6"
    let paleGoldenrod = hex "eee8aa"
    let paleGreen = hex "98fb98"
    let paleTurquoise = hex "afeeee"
    let paleVioletred = hex "db7093"
    let papayaWhip = hex "ffefd5"
    let peachpuff = hex "ffdab9"
    let peru = hex "cd853f"
    let pink = hex "ffc0cb"
    let plum = hex "dda0dd"
    let powderBlue = hex "b0e0e6"
    let rosyBrown = hex "bc8f8f"
    let royalBlue = hex "4169e1"
    let saddleBrown = hex "8b4513"
    let salmon = hex "fa8072"
    let sandyBrown = hex "f4a460"
    let seaGreen = hex "2e8b57"
    let seaShell = hex "fff5ee"
    let sienna = hex "a0522d"
    let skyBlue = hex "87ceeb"
    let slateBlue = hex "6a5acd"
    let slateGray = hex "708090"
    let snow = hex "fffafa"
    let springGreen = hex "00ff7f"
    let steelBlue = hex "4682b4"
    let tan = hex "d2b48c"
    let thistle = hex "d8bfd8"
    let tomato = hex "ff6347"
    let turquoise = hex "40e0d0"
    let violet = hex "ee82ee"
    let wheat = hex "f5deb3"
    let whiteSmoke = hex "f5f5f5"
    let yellowGreen = hex "9acd32"
    let rebeccaPurple = hex "663399"

    // Sizes
    // Absolute
    let px (v: int): Size = sprintf "%dpx" v |> Px
    let inc (v: float): Size = sprintf "%.1fin" v |> In
    let cm (v: float): Size = sprintf "%.1fcm" v |> Cm
    let mm (v: float): Size = sprintf "%.1fmm" v |> Mm
    let pt (v: float): Size = sprintf "%.1fpt" v |> Pt
    let pc (v: float): Size = sprintf "%.1fpc" v |> Pc

    // Relative
    let em (v: float): Size = sprintf "%.1fem" v |> Em
    let rem (v: float): Size = sprintf "%.1frem" v |> Rem
    let ex (v: float): Size = sprintf "%.1fex" v |> Ex
    let ch (v: float): Size = sprintf "%.1fch" v |> Ch
    let vw (v: float): Size = sprintf "%.1fvw" v |> Vw
    let vh (v: float): Size = sprintf "%.1fvh" v |> Vh
    let vmax (v: float): Size = sprintf "%.1fvmax" v |> VMax
    let vmin (v: float): Size = sprintf "%.1fvmin" v |> Vmin

    // Angles
    let deg (v: float): Units.Angle.Angle = sprintf "%.2fdeg" v |> Units.Angle.Deg
    let grad (v: float): Units.Angle.Angle = sprintf "%.2fgrad" v |> Units.Angle.Grad
    let rad (v: float): Units.Angle.Angle = sprintf "%.4frad" v |> Units.Angle.Rad
    let turn (v: float): Units.Angle.Angle = sprintf "%.2fturn" v |> Units.Angle.Turn

    // Font sizes
    let XxSmall = FontSize.XxSmall
    let XSmall = FontSize.XSmall
    let Small = FontSize.Small
    let Medium = FontSize.Medium
    let Large = FontSize.Large
    let XLarge = FontSize.XLarge
    let XxLarge = FontSize.XxLarge
    let XxxLarge = FontSize.XxxLarge
    let Smaller = FontSize.Smaller
    let Larger = FontSize.Larger
