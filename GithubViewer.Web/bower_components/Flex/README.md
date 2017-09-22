<table>
  <tr>
    <td>
      <img src="https://raw.githubusercontent.com/rdgd/Flex/c7659fc59d90a2dd70b9aa9cf0c464934f18eea4/media/logo.png" alt="Flex" height="69">
    </td>
    <td>
      <img src="https://nodei.co/npm/flex-sass.png?downloads=true&downloadRank=true&stars=true" alt="flex-sass" height="69">
    </td>

    <td width="200">
      <img src="https://img.shields.io/bower/v/Flex.svg" alt="Flex">
    </td>
  </tr>
</table>

A CSS Grid which uses flexbox under the hood, and provides a simple CSS class-based API for rapidly building fluid/responsive webpage layouts on a 12 column grid.

### Get it
`bower install Flex` or `npm install flex-sass`

### Base Classes
#### Parent Container

---
`.grid`

Specifies an area in which a particular layout will be defined. Similar to the traditional ".row" class of the horizontal-only grids of yesteryear. Feel free to nest these as you wish, and it will behave as you might hope or expect.

---
`.no-pad`

Removes padding from the parent container and its children/items.

---
`.inline`

Displays as inline-flex instead of flex, which is block.

---

`.wrap`

If the number of specified cols in a parent container exceed 12, then the content will wrap instead of overflow. By default, the framework applies rules applied by this class, but it is exposed through the API regardless.

---

`.wrap-reverse`

Instead of the last element wrapping, the first element wraps, and then the second and so on.

---

`.no-wrap`

Forces overflow instead of wrapping items when they exceed 12 cols worth of space.

---

`.reverse`

Reverses the way flex-order is displayed.

---

`.stack`

Makes flex-direction "column" instead of "row".

---
```
.justify-center
.justify-start
.justify-end
.justify-space-around
.justify-space-between
```
Justifies the content in the container as indicated in the class name.

---

```
.align-baseline
.align-center
.align-start
.align-end
.align-stretch
```
Aligns the items in the container as indicated in the class name.

---

#### Items
The following classes apply **only** to elements which are **direct descendants** of a parent container which has the class `.grid`

---

```
.span-1
.span-2
.span-3
.span-4
.span-5
.span-6
.span-7
.span-8
.span-9
.span-10
.span-11
.span-12
```
Specifies how many grid units the item will span, or its magnitude, on a given vector. For a given parent container the sum of all columns should be <= 12 or either wrapping or overflowing will occur.

---

```
.offset-1
.offset-2
.offset-3
.offset-4
.offset-5
.offset-6
.offset-7
.offset-8
.offset-9
.offset-10
.offset-11
.offset-12
```
Specifies how many grid units the item should be offset from the left. Affects the sum total of grid units for a parent container.

---

```
.offset-1-right
.offset-2-right
.offset-3-right
.offset-4-right
.offset-5-right
.offset-6-right
.offset-7-right
.offset-8-right
.offset-9-right
.offset-10-right
.offset-11-right
.offset-12-right
```
Specifies how many grid units the item should be offset from the right. Affects the sum total of grid units for a parent container.

---

```
.order-1
.order-2
.order-3
.order-4
.order-5
.order-6
.order-7
.order-8
.order-9
.order-10
.order-11
.order-12
```
Specifies the order in which the item should appear rendered on the page, despite their top-down order in the document. All items have an order of 12 by default, so that if an order value < 12 is given to an item, by use of one of these classes, it will be respected.

---

```
.grow-1
.grow-2
.grow-3
.grow-4
.grow-5
.grow-6
.grow-7
.grow-8
.grow-9
.grow-10
.grow-11
.grow-12
```
Specifies the velocity at which the item appears to grow relative to its sibling items.

---
```
.shrink-1
.shrink-2
.shrink-3
.shrink-4
.shrink-5
.shrink-6
.shrink-7
.shrink-8
.shrink-9
.shrink-10
.shrink-11
.shrink-12
```
Specifies the velocity at which the item appears to shrink relative to its sibling items.

---
```
.align-auto
.align-baseline
.align-center
.align-start
.align-end
.align-stretch
```
Overrides the default align-items attribute, which is specified by the `.align-` class on the parent container.

---
### Helpers

---
`.block`

Displays an element as block and gives 100% width.

---

`.block-center`

Displays an element as block and sets margin to auto so that the element is centered in its parent container.

---
`.hide`

Sets display to none.

---
`.show-inline`

Sets display to inline.

---
`.show-block`

Sets display to block.

---
`.show-inline-block`

Sets display to inline-block.

---

`.text-left`

Justifies contained text to the left.

---
`.text-center`

Justifies contained text to the center.

---
`.text-right`

Justifies contained text to the right.

---
### Breakpoints
Breakpoints are based purely on viewport size. To target a specific viewport size, simply append '-xl', '-lg', '-md', 'sm', 'xs' to any base class or helper class.

###### `-xl` (max-width 1600px)
###### `-lg` (max-width 1280px)
###### `-md` (max-width 960px)
###### `-sm` (max-width 640px)
###### `-xs` (max-width 320px)

## Examples

### Simple responsive behavior
Goal: When the viewport size becomes smaller than 640px, stack the elements in our grid container.

By default Flex will wrap any grid items which exceed the size of the container, so we can simply allot a greater number of columns to different elements at different sizes.
```
<div class="grid">
  <aside class="span-3 span-12-sm">
  </aside>
  <div class="span-9 span-12-sm">
  </div>
</div>
```

If our grid parent has the `.no-wrap` class applied, we can still achieve this by indicating that we want the items in the grid to simply stack when the viewport is small using `.stack-sm` class.
```
<div class="grid no-wrap stack-sm">
  <aside class="span-3">
  </aside>
  <div class="span-9">
  </div>
</div>
```

### Centering grid items
Goal: We have two columns, one that spans 2 grid units and the other 3 grid units. We want them centered in the grid.

Since there are an odd number of grid units we need to center in the page, we need to make the amount of space the content takes up even by adding one unit of offset to the second item. Since they will then take up 6 units of space, we have a remaining 6 units to distribute on either side, which is achieved by setting the offset of the first unit to 3 because there is just a remaining 3 units worth of space empty on the right side.
```
<div class="grid">
  <aside class="span-2 offset-3">
  </aside>
  <div class="span-3 offset-1">
  </div>
</div>
```
