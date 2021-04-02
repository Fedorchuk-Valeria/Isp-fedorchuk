#pragma once

#ifdef TRIANGLE_EXPORTS
#define TRIANGLE_API __declspec(dllexport)
#else
#define TRIANGLE_API __declspec(dllimport)
#endif


extern "C" TRIANGLE_API double CosineTheorem(double a, double b, double C);

extern "C" TRIANGLE_API double SineTheorem(double c, double C, double b);

extern "C" TRIANGLE_API  double Third—orner(double B, double C);

extern "C" TRIANGLE_API double Perimeter(double a, double b, double c);

extern "C" TRIANGLE_API double Square(double a, double b, double C);

extern "C" TRIANGLE_API double Inscribed—ircle(double S, double P);

extern "C" TRIANGLE_API double Circumscribed—ircle(double a, double b, double c, double S);
