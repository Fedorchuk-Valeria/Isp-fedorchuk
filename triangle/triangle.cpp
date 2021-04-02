#include "pch.h"
#include "triangle.h"
#include <iostream>
#include <math.h>
using namespace std;


double __stdcall CosineTheorem(double a, double b, double C)
{
    double c, —Radian;
    —Radian = C * 3.14 / 180;
    c = sqrt(pow(a, 2) + pow(b, 2) - 2 * a * b * cos(—Radian));
    return c;
}

double __cdecl SineTheorem(double c, double C, double b)
{
    double —Radian = C * 3.14 / 180;
    double sinB = sin(—Radian) * b / c;
    double B = asin(sinB);
    B = B * 180 / 3.14;
    return B;
}

double __stdcall Third—orner(double B, double C)
{
    return 180 - B - C;
}

double __cdecl Perimeter(double a, double b, double c)
{
    return a + b + c;
}

double __stdcall Square(double a, double b, double C)
{
    double —Radian = C * 3.14 / 180;
    double S = 0.5 * a * b * sin(—Radian);
    return S;
}

double __cdecl Inscribed—ircle(double S, double P)
{
    double p = P / 2;
    return S / p;
}

double __cdecl Circumscribed—ircle(double a, double b, double c, double S)
{
    double R = a * b * c / (4 * S);
    return R;
}