/* #region Microservice */
export interface IApiMicroserviceResponseDto{
    id : string, //Uuid
    name : string
    methods: IApiMethodResponseDto[]
}

export interface IApiMicroserviceRequestDto{
    id? : string, //Uuid
    name : string
    swaggerContract? : string,
    methods?: IApiMethodRequestDto[]
}
/* #endregion Microservice */

/* #region Methods */
export interface IApiMethodResponseDto{
    id : string, //Uuid
    verb : string
    path: string,
    microservice: IApiMicroserviceResponseDto
}

export interface IApiMethodRequestDto{
    id? : string, //Uuid
    verb : string
    path: string,
    microservice: IApiMicroserviceResponseDto
}
/* #endregion Methods */

/* #region Rols */
export interface IApiRoleResponseDto{
    id : string, //Uuid
    name : string
    methods: IApiMethodResponseDto[]
}

export interface IApiRoleRequestDto{
    id? : string, //Uuid
    name : string
    methods: string[]
}
/* #endregion Rols */

/* #region Users */
export interface IApiUserRequestDto{
    id : string, //Uuid
    username : string
    name : string
    surname : string
    roles: string[]
}

export interface IApiUserResponseDto{
    id : string, //Uuid
    username : string
    password : string
    name : string
    surname : string
    roles: IApiRoleResponseDto[]
}

export interface IApiLoginUserDto{
    username : string
    password : string
}

export interface IApiSignUpDto{
    username : string
    password : string
    name : string
    surname : string
}
/* #endregion Users */
