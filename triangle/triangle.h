#pragma once

#ifdef TRIANGLE_EXPORTS
#define TRIANGLE_API __declspec(dllexport)
#else
#define TRIANGLE_API __declspec(dllimport)
#endif

extern "C" TRIANGLE_API double __stdcall CosineTheorem(double a, double b, double C);

extern "C" TRIANGLE_API double __cdecl SineTheorem(double c, double C, double b);

extern "C" TRIANGLE_API double __stdcall ThirdÑorner(double B, double C);

extern "C" TRIANGLE_API double __cdecl Perimeter(double a, double b, double c);

extern "C" TRIANGLE_API double __stdcall Square(double a, double b, double C);

extern "C" TRIANGLE_API double __cdecl InscribedÑircle(double S, double P);

extern "C" TRIANGLE_API double __cdecl CircumscribedÑircle(double a, double b, double c, double S);
