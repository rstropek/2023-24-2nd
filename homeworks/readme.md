# Geometry Calculator

## Description

You have to create a class library that is capable of calculating the area of different geometric figures (rectangle, circle, triangle). Additionally, the library must contain methods for increasing the area of figures by a given factor (e.g. *2* for doubling the area).

In this first version of the example, you should *only* use *static* classes. We will change that design in later versions of the example.

## Functional Requirements

### Project Folder Structure

Create an empty folder. Choose a name for the folder.

### Class Library

1. Create a class library `GeometryCalculator`.
2. Add a static class `RectangleMath` to the library. It mus offer the following functions:
    1. `static double CalculateArea(double width, double height)` - Calculates the area of a rectangle with the given width and height.
    2. `static (double width, double height) CalculateScaledDimensions(double width, double height, double factor)` - Calculates the width and height of a rectangle whose area is the given factor times the area of the rectangle with the given width and height. The aspect ratio (width/height) must be preserved.
3. Add a static class `CircleMath` to the library. It mus offer the following functions:
    1. `static double CalculateArea(double radius)` - Calculates the area of a circle with the given radius.
    2. `static double CalculateScaledDimensions(double radius, double factor)` - Calculates the radius of a circle whose area is the given factor times the area of the circle with the given radius.
4. Add a static class `TriangleMath` to the library. It mus offer the following functions:
    1. `static double CalculateArea(double baseLength, double height)` - Calculates the area of a triangle with the given base and height.
    2. `static (double baseLength, double height) CalculateArea(double baseLength, double height, double factor)` - Calculates the base and height of a triangle whose area is the given factor times the area of the triangle with the given base and height. The aspect ratio (base/height) must be preserved.

### Console Application

1. Create a console application `GeometryCalculatorApp`.
2. Add a reference to the class library `GeometryCalculator`.
3. Implement the following functionality in the `Main` method:
    1. Ask the user to enter the type of the geometric figure (rectangle, circle, triangle).
    2. Ask the user to enter the required parameters (width, height, radius, base, height).
    3. Ask the user to enter the required factor.
    4. Calculate and print the area of the geometric figure and the area of the scaled geometric figure (rounded to 3 decimal places).
    5. Print the new parameters after scaling the geometric figure.

## Mathematical Background

### Rectangle

* $ w $ is the original width of the rectangle
* $ h $ is the original height of the rectangle
* $ f $ is the scaling factor
* $ w' $ is the new width of the rectangle
* $ h' $ is the new height of the rectangle.

$$ w' = \sqrt{f} w $$
$$ h' = \sqrt{f} h $$

### Circle

* $ r $ is the original radius of the circle
* $ f $ is the scaling factor
* $ r' $ is the new radius of the circle.

$$ r' = \sqrt{f} r $$

### Triangle

* $ b $ is the original base of the triangle
* $ h $ is the original height of the triangle
* $ f $ is the scaling factor
* $ b' $ is the new base of the triangle
* $ h' $ is the new height of the triangle.

$$ b' = \sqrt{f} b $$
$$ h' = \sqrt{f} h $$
