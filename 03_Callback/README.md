# Callback

## Overview

Callback is a design pattern, which may be implemented in many ways in C#.
It's a way to inject a routine to a function so that it can be invoked when the time is right.

## Implementation

There are many several implementations:

1. **Delegates**: Delegates are a type-safe way to pass a method as an argument to another method. To create a callback using a delegate, you need to store a function address inside a variable.
2. **Events**: Events are a special type of callback that allow multiple functions to be called when an event occurs. To create an event, you need to define a delegate type and then declare an event of that type.
3. **Lambda expressions**: Lambda expressions are a shorthand way of creating delegates.

These are just a few examples.