## API
/api/translations/{ISO639-1 language id}
- GET - Return translations for a specific language (verified or unverified)

/api/translations/{ISO639-1 language id}/{translation key}
- PATCH - Request to overwrite unverified translation with verified translation

/api/translations
- POST - Translate all english tags into all supported languages