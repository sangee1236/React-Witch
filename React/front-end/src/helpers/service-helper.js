export const getRequestOptions = (requestheaders, body = null) => {
    if (body) {
        return {
            method: requestheaders,
            headers: {'Content-Type': 'application/json'},
            body: JSON.stringify(body)
        }
    } else {
        return {
            method: requestheaders,
            headers: {'Content-Type': 'application/json'}
        }
    }
}

export const getApiUrl = (controller) => {
    return 'http://localhost:8153/api/' + controller;
}
