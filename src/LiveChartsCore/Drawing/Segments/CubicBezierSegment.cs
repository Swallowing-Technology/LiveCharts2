﻿// The MIT License(MIT)
//
// Copyright(c) 2021 Alberto Rodriguez Orozco & LiveCharts Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using LiveChartsCore.Motion;

namespace LiveChartsCore.Drawing.Segments;

/// <summary>
/// Defines a cubic bezier segment.
/// </summary>
public class CubicBezierSegment : Animatable, IPathSegment
{
    private readonly FloatMotionProperty _x0Property;
    private readonly FloatMotionProperty _y0Property;
    private readonly FloatMotionProperty _x1Property;
    private readonly FloatMotionProperty _y1Property;
    private readonly FloatMotionProperty _x2Property;
    private readonly FloatMotionProperty _y2Property;

    /// <summary>
    /// Initializes a new instance of the <see cref="CubicBezierSegment"/> class.
    /// </summary>
    public CubicBezierSegment()
    {
        _x0Property = RegisterMotionProperty(new FloatMotionProperty(nameof(X0), 0f));
        _y0Property = RegisterMotionProperty(new FloatMotionProperty(nameof(Y0), 0f));
        _x1Property = RegisterMotionProperty(new FloatMotionProperty(nameof(X1), 0f));
        _y1Property = RegisterMotionProperty(new FloatMotionProperty(nameof(Y1), 0f));
        _x2Property = RegisterMotionProperty(new FloatMotionProperty(nameof(X2), 0f));
        _y2Property = RegisterMotionProperty(new FloatMotionProperty(nameof(Y2), 0f));
    }

    /// <summary>
    /// Gets or sets the x0.
    /// </summary>
    /// <value>
    /// The x0.
    /// </value>
    public float X0 { get => _x0Property.GetMovement(this); set => _x0Property.SetMovement(value, this); }

    /// <summary>
    /// Gets or sets the y0.
    /// </summary>
    /// <value>
    /// The y0.
    /// </value>
    public float Y0 { get => _y0Property.GetMovement(this); set => _y0Property.SetMovement(value, this); }

    /// <summary>
    /// Gets or sets the x1.
    /// </summary>
    /// <value>
    /// The x1.
    /// </value>
    public float X1 { get => _x1Property.GetMovement(this); set => _x1Property.SetMovement(value, this); }

    /// <summary>
    /// Gets or sets the y1.
    /// </summary>
    /// <value>
    /// The y1.
    /// </value>
    public float Y1 { get => _y1Property.GetMovement(this); set => _y1Property.SetMovement(value, this); }

    /// <summary>
    /// Gets or sets the x2.
    /// </summary>
    /// <value>
    /// The x2.
    /// </value>
    public float X2 { get => _x2Property.GetMovement(this); set => _x2Property.SetMovement(value, this); }

    /// <summary>
    /// Gets or sets the y2.
    /// </summary>
    /// <value>
    /// The y2.
    /// </value>
    public float Y2 { get => _y2Property.GetMovement(this); set => _y2Property.SetMovement(value, this); }

    /// <inheritdoc cref="IPathSegment.Id"/>
    public int Id { get; set; }

    /// <inheritdoc cref="IPathSegment.CopyTo(IPathSegment)"/>
    public void CopyTo(IPathSegment source)
    {
        var cubic = (CubicBezierSegment)source;

        CurrentTime = cubic.CurrentTime;

        cubic.X0 = X0;
        cubic.X1 = X1;
        cubic.X2 = X2;
        cubic.Y0 = Y0;
        cubic.Y1 = Y1;
        cubic.Y2 = Y2;
    }
}
