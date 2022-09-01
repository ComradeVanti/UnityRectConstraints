# Unity Rect-constraints

[![openupm](https://img.shields.io/npm/v/dev.comradevanti.rect-constraints?label=openupm&registry_uri=https://package.openupm.com)](https://openupm.com/packages/dev.comradevanti.rect-constraints/)

This Unity package adds utility methods for layouting `Rect` objects, similarly
to [Androids Constraint layout](https://developer.android.com/develop/ui/views/layout/constraint-layout).
This can be used in `GUI` and `EditorGUI` code.

For specific instructions and guides check out the [Wiki](https://github.com/ComradeVanti/UnityRectConstraints/wiki).

## Installation

The quickest way is to install via [OpenUPM](https://openupm.com)
using `openupm add dev.comradevanti.rect-constraints`. Or install manually
as [git dependency](https://docs.unity3d.com/Manual/upm-ui-giturl.html)
from `https://github.com/ComradeVanti/UnityRectConstraints.git` or download as
zip and [import locally](https://docs.unity3d.com/Manual/upm-ui-local.html).
If you
decide to install manually, make sure your project includes the
following [scoped registry](https://docs.unity3d.com/Manual/upm-scoped.html):

```json
{
  "name": "package.openupm.com",
  "url": "https://package.openupm.com",
  "scopes": [
    "com.openupm",
    "dev.comradevanti.rect-constraints"
  ]
}
```

## Roadmap

Features that could be added in the future

- Percentage-based sizes
- Min/Max sizes
- Weights