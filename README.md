# ListRandomnessExtensions

A collection of generic `IList<T>` extension methods for random selection, shuffling, inserting, and removing elements. Supports both standard random behavior and deterministic random sequences using a seeded `Random` instance.

## Installation

Add via Unity Package Manager using the Git URL:

```text
https://github.com/MegaMulti/ListRandomnessExtensions.git

Quick Start

using System.Collections.Generic;
using MegaMulti.ListRandomnessExtensions;

var list = new List<int> { 1, 2, 3, 4, 5 };

// Get a random element
int value = list.GetRandom();

// Shuffle the list
list.Shuffle();

// Remove a random element
int removed = list.PopRandom();

// Remove the last element
int last = list.PopLast();

// Insert an element at a random position
list.AddAtRandom(10);

Seeded Random

For deterministic and reproducible results, create a Random instance with a seed and reuse it across operations.

var random = new Random(12345);

var list = new List<int> { 1, 2, 3, 4, 5 };

// All operations use the same seeded random sequence
list.Shuffle(random);

int value = list.GetRandom(random);

int removed = list.PopRandom(random);

list.AddAtRandom(10, random);

Using the same seed and performing the same operations in the same order produces the same random sequence.

var random = new Random(12345);

This can be useful for procedural generation, simulations, testing, games, and other systems that require reproducible random behavior.
API Reference
Get Random Element
Method	Description
GetRandom()	Returns a random element using the shared random generator.
GetRandom(random)	Returns a random element using the provided Random instance.

int value = list.GetRandom();

var random = new Random(12345);
int seededValue = list.GetRandom(random);

    Throws InvalidOperationException if the list is empty.

Shuffle
Method	Description
Shuffle()	Shuffles the list in place using the shared random generator.
Shuffle(random)	Shuffles the list in place using the provided Random instance.

list.Shuffle();

var random = new Random(12345);
list.Shuffle(random);

    Uses the Fisher-Yates shuffle algorithm.

Pop Random
Method	Description
PopRandom()	Removes and returns a random element using the shared random generator.
PopRandom(random)	Removes and returns a random element using the provided Random instance.

int value = list.PopRandom();

var random = new Random(12345);
int seededValue = list.PopRandom(random);

    Throws InvalidOperationException if the list is empty.

Pop Last
Method	Description
PopLast()	Removes and returns the last element in the list.

int value = list.PopLast();

    Throws InvalidOperationException if the list is empty.

Add At Random
Method	Description
AddAtRandom(value)	Inserts a value at a random position using the shared random generator.
AddAtRandom(value, random)	Inserts a value at a random position using the provided Random instance.

list.AddAtRandom(10);

var random = new Random(12345);
list.AddAtRandom(20, random);

The value can be inserted at any position, including the beginning or end of the list.
Random Generators

The extensions provide two ways to control randomness.
Shared Random

Calling an extension without a Random parameter uses an internally shared random generator.

list.Shuffle();

int value = list.GetRandom();

list.AddAtRandom(10);

Use this when deterministic results are not required.
Custom Random

Pass your own Random instance when you need control over the random sequence.

var random = new Random(12345);

list.Shuffle(random);
list.GetRandom(random);
list.PopRandom(random);
list.AddAtRandom(10, random);

The same Random instance should be reused when you want all operations to be part of the same deterministic sequence.
Supported Types

All operations work with any type implementing IList<T>.

var numbers = new List<int>();
var names = new List<string>();
var objects = new List<MyObject>();

For example:

var names = new List<string>
{
    "Alice",
    "Bob",
    "Charlie",
    "Dave"
};

var random = new Random(12345);

names.Shuffle(random);

string name = names.GetRandom(random);

Requirements

    C# with IList<T> support

    .NET / Unity compatible

    No external dependencies
