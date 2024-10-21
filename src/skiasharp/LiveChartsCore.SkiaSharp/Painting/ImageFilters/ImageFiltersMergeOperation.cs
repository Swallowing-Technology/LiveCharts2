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

using LiveChartsCore.SkiaSharpView.Drawing;
using SkiaSharp;

namespace LiveChartsCore.SkiaSharpView.Painting.ImageFilters;

/// <summary>
/// Merges multiple image filters.
/// </summary>
/// <seealso cref="ImageFilter" />
/// <remarks>
/// Initializes a new instance of the <see cref="ImageFiltersMergeOperation"/> class.
/// </remarks>
/// <param name="imageFilters">The image filters.</param>
/// <param name="cropRect">The crop rect.</param>
public class ImageFiltersMergeOperation(ImageFilter[] imageFilters) : ImageFilter
{
    private readonly ImageFilter[] _filters = imageFilters;

    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns></returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public override ImageFilter Clone()
    {
        return new ImageFiltersMergeOperation(_filters);
    }

    /// <summary>
    /// Creates the image filter.
    /// </summary>
    /// <param name="drawingContext">The drawing context.</param>
    /// <exception cref="System.NotImplementedException"></exception>
    public override void CreateFilter(SkiaSharpDrawingContext drawingContext)
    {
        var imageFilters = new SKImageFilter[_filters.Length];
        var i = 0;

        foreach (var item in _filters)
        {
            item.CreateFilter(drawingContext);
            if (item.SKImageFilter is null) throw new System.Exception("Image filter is not valid");
            imageFilters[i++] = item.SKImageFilter;
        }

        SKImageFilter = SKImageFilter.CreateMerge(imageFilters);
    }

    /// <summary>
    /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
    /// </summary>
    public override void Dispose()
    {
        foreach (var item in _filters)
        {
            item.Dispose();
        }
    }
}
