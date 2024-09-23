create database tasks_db;

create table users(
                      id uuid primary key default gen_random_uuid(),
                      username varchar(255) unique,
                      email varchar(255) unique,
                      passwordhash varchar(255),
                      createdat date
);

create table categories(
                           id uuid primary key default gen_random_uuid(),
                           name varchar(255) unique,
                           createdat date
);

create table tasks(
                      id uuid primary key default gen_random_uuid(),
                      title varchar(255) not null,
                      description varchar(255),
                      iscompleted bool,
                      duedate date,
                      userid uuid references users (id),
                      categoryid uuid references categories (id),
                      priority int,
                      createdat date
);

create table comments(
                         id uuid primary key default gen_random_uuid(),
                         taskid uuid references tasks (id),
                         userid uuid references users (id),
                         content varchar(255),
                         createdat date
);

create table taskattachments(
                                id uuid primary key default gen_random_uuid(),
                                taskid uuid references tasks (id),
                                filepath varchar(255),
                                createdat date
);

create table taskhistoires(
                              id uuid primary key default gen_random_uuid(),
                              taskid uuid references tasks (id),
                              changedescription varchar(255),
                              createdat date
);






