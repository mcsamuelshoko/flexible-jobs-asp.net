# Database Tables

        database:   MS-SQL
        dialect:    sql
        charset:    utf8

---

> **NOTE** : all tables have an `id` field which will not be shown below.

## Users

    - avatar    <string>,
    - fname     <string>,
    - lname     <string>,
    - email     <string>(unique),
    - password  <string>,
    - type      <string>[ admin, employer, employee ],
    - status    <string> [active, banned]

## Qualifications

    - userId,   <string>(unique)
    - details,  <string>

## Companies

    - avatar,
    - name,
    - website,
    - hq_address,
    - details,
    - email,
    - password,
    - type,
    - status

## Jobs

    - name,
    - email,
    - salary,
    - branch,
    - expires,
    - details,
    - status    <string>[standby,waiting,published,approved,denied]

## Messages

    - ownerId,
    - recipientId,
    - content,
    - created,
    - updated

## applications

    - userId,
    - companyId,
    - favorite,
    - status

## reports

    - userId
    - companyId
    - details
    - created
    - updated