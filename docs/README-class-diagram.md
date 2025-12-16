Class Diagram (PlantUML)

Files:
- `docs/class-diagram.puml` — PlantUML source for the class diagram.

How to render:

1) Using VS Code
- Install the "PlantUML" extension (jebbs.plantuml).
- Open `docs/class-diagram.puml` and use the preview (Alt+D or the extension commands) to render.

2) Using PlantUML CLI (requires Java)
- Download `plantuml.jar` and run:

```powershell
java -jar plantuml.jar docs\class-diagram.puml
```

This generates `docs/class-diagram.png` next to the PUML file.

3) Using Docker

```powershell
docker run --rm -v ${PWD}:/workspace plantuml/plantuml:latest /workspace/docs/class-diagram.puml
```

Notes / Legend
- The diagram is grouped into 3 main panes: `Blazor App`, `HTTP / API Controllers`, and `Domain / Models & DTOs`.
- `Blazor App` includes Pages, Layout/Components and Client Services.
- `WasteServiceClient` represents the front-end HTTP wrapper (the `WasteService` in the project).
- The PlantUML file is intentionally high-level (visualization only). If you want a more detailed diagram (showing properties/methods for every class file in the repo), tell me and I can expand it.
