# Design document

## User control
- Lets user select a type of plant in gui
- plant selected with right-click on ground
- left-clicking on existing plant brings up function menu (e.g. to grow plant)

## Classes & methods
```
> abstract class plant
        + string genus { get; }
        - float maxHeight
        + abstract grow (float cm)
        + die()
    > tree()
        + shedLeaves() //sheds all
        + shedLeaves(float percentage)
    > flower
        - string color
        + bloom()
    > grass()
        + spread()
```

    