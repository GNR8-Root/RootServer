# Blazor/Airtable Schema-Driven UI Generator

Project overview

---

## Introduction and Background

### Experience

I have 25+ years of software development & UXD experience spanning multiple technology stacks and domains:

* First decade focused on Flash, Maya 3D, advanced UI animation, and interactive media
* Second 5y transitioned to HTML5/CSS/JS, React, Angular, systems like Wordpress, Prestashop, Textpattern, responseCMS
* Recent decade has been primarily .NET ecosystem, Unity3D & Blazor

My expertise centers on event- & data-driven workflows, visual- & editor-tools, dynamic content generation. This background directly informs the architectural decisions in this project.


### Project

This project began 2.5 years ago as a simple Blazor experiment, but it quickly evolved into a layered UI and data framework. Over time, I designed a schema-driven architecture, an internal editor environment, and a metadata pipeline capable of generating UI dynamically from structured definitions.

The codebase is a working proof-of-concept showing how to build reusable UI primitives, metadata-driven rendering, and an integrated editor + runtime environment within a single Blazor Server project. See: [Detailed Documentation](Docs/detailed.md)

The development is done on a Mac using JetBrains Rider, it was only tested on the local machine in Chrome, so it might not work on other browsers, for a visual explanation how the AIRTABLE data drives the UI see: [Data Drives UI](Docs/data-drives-ui.md)

it was coded before the AI hype took off, so all was handwritten, with some (alot;) help of StackOverFlow, google, youtube, udemy, and other resources, so it might give a good insight on my design and thought process. It is a proof of concept for a new approach to UI development with blazor instead of using the UI Toolkit of Unity3d. Which is kind of similar to HTML/CSS/JS, but lacks maturity.

The goal was to check if it would be possible to create a framework that would allow me to create complete (instanced) applications without the need of writing any code, and at the same time keep the architecture similar to previous projects in Unity3d, so that previous written code could be implemented in a later stage as well.

In it's current state it is not finalized yet, when AI took off, there was a lot of research to be done in how to implement GenAi in my daily workflow, and how to implement it in a structural, strategic, and save way into this framework. Currently, each table needs to be hand-coded in chsarp, this is very cumbersome and doesn't make the project dynamic, the main goal is to use a JSON of all the database-schema and generate the UI from that, at the same time there are still some fields missing that are standard in AIRTABLE. More on: [Airtable](Docs/review.md)




What started as a prototype has now become the foundation for a broader, plugin-based .NET meta-framework, one that supports multiple future projects with minimal or even zero code duplication. This vision extends into AI-assisted development, CosmosDB-backed schema storage, and automated Azure infrastructure deployment, forming a flexible platform that can generate applications, editors, and entire environments from metadata alone.

This project (AIRTABLE plugin in a host) is part of 3 separated research projects that are being merged into one final solution. A core framework with 3 plugins (AIRTABLE, AZUREadmin, AZUREfoundryAI) that all together are a toolkit for rappid prototyping & development of a complete application. See: [Future Vision](Docs/detailed.md)



---

The manual is created with the help of AI, it was fed the complete codebase of this project, the AZUREadmin and the AZUREfoundryAI, all the jsons of the Airtables, with notes, todos, designpatterns, idea's etc. And from there on the AI was directed to compress it in this form, with some human help. It contains information about this project, but also the "bigger parent" project where it will reside in the future.

The code review is 100% AI generated, without "human" adjustments. [AI Generated Code Review](Docs/review.md)

---

## What This Project Demonstrates

### **A clean, layered architecture**
- **_Core** – foundational building blocks (events, base classes, state, display/field/action patterns)
- **_Editor** – internal editor UI (views, panels, workspace, tools)
- **Airtable** – integration layer with caching, typed table models, JSON serialization
- **_Site** – public-facing website assembled from reusable sections

---

### **Schema-driven UI rendering**
- Tables, rows, and fields from Airtable are represented in a consistent abstraction
- UI is generated from metadata rather than from hardcoded layouts
- JSON caching enables fast local development and offline capability

---

### **Internal Editor Environment**
Includes:
- Table browsing
- Row/field inspection (partially implemented)
- Airtable → JSON sync utility
- Logging and pointer-based state management
- Reusable views, widgets, panels, and selectors

---

### **Separation of concerns**
Each layer follows a clear and consistent folder/naming pattern (00_Core → 08_Panels), making the architecture predictable, scalable, and easy to navigate.

---

## Highlights for Code Review

If you're reviewing this codebase, the most relevant areas are:

### **1. Core Architecture**
`Shared/_Core`  
Foundation classes, UI patterns, services, and event-driven state flow.

### **2. Editor Framework**
`Shared/_Editor`  
Composed view/panel architecture, dynamic UI generation, and service-driven layouts.

### **3. Airtable Integration Layer**
`Shared/Airtable`  
Strongly typed models, sync pipeline, JSON caching, serialization, and transformation utilities.

### **4. Section-Based Site Rendering**
`Shared/_Site`  
Public website composed of modular sections using a consistent wrapper + base component pattern.

These folders provide a clear overview of the intended design principles and architectural approach.

---

## Technology Stack

- **Blazor Server (.NET)**
- **Airtable API integration + local JSON caching**
- **Event-driven UI patterns**
- **Blazorise (Bootstrap5 + FontAwesome)**
- **C# component architecture with strong abstractions**

---

## Document Structure

This README serves as a high-level overview.  
A more detailed technical explanation of the architecture and implementation can be found in:

---

* [Detailed Documentation](Docs/01__detailed.md) (Docs/01__detailed.md)
* [Data Drives UI](Docs/02__data-drives-ui.md) (Docs/02__data-drives-ui.md)
* [Airtable](Docs/03__airtable.md) (Docs/03__airtable.md)
* [Future Vision](Docs/04__vision.md) (Docs/04__vision.md)
* [AI Generated Code Review](Docs/05__review.md) (Docs/05__review.md)

---

to test the current state of the project: please request a key at:

**[arnold@znzr.io](mailto:arnold@znzr.io)**

---