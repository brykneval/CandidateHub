# Job Candidate Hub

## Improvements
* Code has scope for a generic repository like CandidateHubRepository:Repository<T>
* A proper cache libraries can be implemented, which already has proper cache options such as expiration, notifs, usage stats etc.
* Proper logging incase of errors and also more logs for debugging.

## Assumption
* Added arbitary length for string properties such as FirstName, LastName etc
* Links are not valided for now as people can use shorten urls too.
* For embedded db, used sqlite. Using sqlite over sqlserver also loosely projects migration from one Db to other possible.

## Time Spent
* Projecting possible solution: 1 hrs
* Coding: 3 hrs
* Tests: 1 hrs
* Extras / Research: 1 hrs
* Total: 6 hrs
