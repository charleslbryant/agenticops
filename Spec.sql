-- PostgreSQL SQL Schema
-- Funnels represent the highest level of the workflow hierarchy
CREATE TABLE funnels (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    index INT NOT NULL DEFAULT 0
);

-- Phases belong to a funnel
CREATE TABLE phases (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    index INT NOT NULL DEFAULT 0,
    funnel_id INT REFERENCES funnels(id)
);

-- Stages belong to a phase and have purpose and goals
CREATE TABLE stages (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    purpose TEXT,
    goal TEXT,
    index INT NOT NULL DEFAULT 0,
    phase_id INT REFERENCES phases(id)
);

-- Workflow steps belong to a stage
CREATE TABLE workflow_steps (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    description TEXT,
    index INT NOT NULL DEFAULT 0,
    stage_id INT REFERENCES stages(id)
);

-- Roles define responsibilities within workflow steps
CREATE TABLE roles (
    id SERIAL PRIMARY KEY,
    title TEXT NOT NULL,
    responsibilities TEXT
);

-- Inputs define required artifacts for a step
CREATE TABLE inputs (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    source TEXT
);

-- Notifications track alerts and messages in workflow steps
CREATE TABLE notifications (
    id SERIAL PRIMARY KEY,
    notice TEXT NOT NULL,
    recipients TEXT
);

-- Meetings track scheduled discussions
CREATE TABLE meetings (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL
);

-- Outputs define artifacts produced by a workflow step
CREATE TABLE outputs (
    id SERIAL PRIMARY KEY,
    name TEXT NOT NULL,
    description TEXT
);

-- Events define triggers in workflow steps
CREATE TABLE events (
    id SERIAL PRIMARY KEY,
    type TEXT NOT NULL,
    name TEXT NOT NULL
);

-- Event handlers define responses to workflow events
CREATE TABLE event_handlers (
    id SERIAL PRIMARY KEY,
    event TEXT NOT NULL,
    condition TEXT,
    action TEXT
);

-- Automation hooks define API-based integrations
CREATE TABLE automation_hooks (
    id SERIAL PRIMARY KEY,
    system TEXT NOT NULL,
    api_call TEXT NOT NULL
);
