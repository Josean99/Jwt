--
-- PostgreSQL database dump
--

-- Dumped from database version 15.3
-- Dumped by pg_dump version 15.3

-- Started on 2024-01-19 10:55:51

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

--DROP DATABASE "JwtMS";
--
-- TOC entry 3372 (class 1262 OID 16492)
-- Name: JwtMS; Type: DATABASE; Schema: -; Owner: postgres
--

--CREATE DATABASE "JwtMS" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Spain.1252';


ALTER DATABASE "JwtMS" OWNER TO postgres;

\connect "JwtMS"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 218 (class 1259 OID 16595)
-- Name: Methods; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Methods" (
    "Id" uuid NOT NULL,
    "Verb" text NOT NULL,
    "Path" text NOT NULL,
    "IdMicroservice" uuid NOT NULL,
    "FechaBaja" timestamp without time zone
);


ALTER TABLE public."Methods" OWNER TO postgres;

--
-- TOC entry 215 (class 1259 OID 16574)
-- Name: Microservices; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Microservices" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "FechaBaja" timestamp without time zone
);


ALTER TABLE public."Microservices" OWNER TO postgres;

--
-- TOC entry 219 (class 1259 OID 16641)
-- Name: RoleMethod; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."RoleMethod" (
    "MethodId" uuid NOT NULL,
    "RoleId" uuid NOT NULL
);


ALTER TABLE public."RoleMethod" OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16581)
-- Name: Roles; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Roles" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "FechaBaja" timestamp without time zone
);


ALTER TABLE public."Roles" OWNER TO postgres;

--
-- TOC entry 220 (class 1259 OID 16656)
-- Name: UserRole; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."UserRole" (
    "RoleId" uuid NOT NULL,
    "UserId" uuid NOT NULL
);


ALTER TABLE public."UserRole" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16588)
-- Name: Users; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."Users" (
    "Id" uuid NOT NULL,
    "Username" text NOT NULL,
    "Password" text NOT NULL,
    "Name" text NOT NULL,
    "Surname" text NOT NULL,
    "FechaBaja" timestamp without time zone
);


ALTER TABLE public."Users" OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 16569)
-- Name: __EFMigrationsHistory; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);


ALTER TABLE public."__EFMigrationsHistory" OWNER TO postgres;

--
-- TOC entry 3364 (class 0 OID 16595)
-- Dependencies: 218
-- Data for Name: Methods; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('41058866-8a02-4ff4-91c9-c1c5c8bf9065', 'GET', '/api/Method/GetByMicroservice', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('19565a4d-9516-4ec5-b911-724a2f181bd8', 'GET', '/api/Method/GetByRole', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('3e17df33-587a-467b-a777-3936d18ee115', 'POST', '/api/Roles/Post', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('66db3ba3-009d-4db0-99b7-53b0dda49dfa', 'POST', '/api/Microservice/Post', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('6f29b00c-5fe4-4952-9d03-a1d5b8d3ac86', 'POST', '/api/Login/Post', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('80dea577-c5fe-4195-9676-62eb04a48bcc', 'POST', '/api/SignUp/Post', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('959edc45-0522-4e89-a6ed-b88829bdd706', 'POST', '/api/Method/Post', '3fa85f64-5717-4562-b3fc-2c963f66afa6', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('c30a1c25-b3af-44a5-a472-dcd3279501e3', 'POST', '/api/Categories/Post', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('7125f39b-77b2-41bf-8b72-c81217b7ec70', 'POST', '/api/Texts/Post', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('441ffe07-78ea-4498-9898-e903fb3e638d', 'POST', '/api/Products/Post', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('b1aa7dba-2115-4299-a721-c0be68600a11', 'POST', '/api/Images/Post', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('0fc154d8-e741-4855-af56-50eb5086751d', 'POST', '/api/Brands/Post', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('4e9eb2b1-6051-4f0b-a742-7fc22cb4b15c', 'PUT', '/api/Categories/Put', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('865c4b3e-43ca-4330-850d-b6337e387b29', 'PUT', '/api/Products/Put', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('51a0817b-0c51-4c2c-aafe-006c6ed60b4a', 'PUT', '/api/Images/Put', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('e9373509-425b-469a-82eb-7291cf64e382', 'PUT', '/api/Texts/Put', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('94eefd07-2cdf-47ff-8d52-1834e09fcc31', 'PUT', '/api/Brands/Put', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('a11361cd-419b-4149-b8c8-0645ced23172', 'PUT', '/api/Brands/SoftDelete', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('ddd574ac-91d7-4ba1-b925-51383f5de53e', 'PUT', '/api/Categories/SoftDelete', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('c730fad7-65bd-40ae-b1e8-2607950876bc', 'PUT', '/api/Products/SoftDelete', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('fbee7bca-beb1-4e51-87d5-70da8e549cea', 'PUT', '/api/Images/SoftDelete', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('3c0ae841-9b8a-429d-9a8e-947925a85f9c', 'PUT', '/api/Texts/SoftDelete', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('5a44fa44-98bd-4c77-9566-7d89e339cbb4', 'DELETE', '/api/Brands/Delete', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('d96dba75-22b3-4543-acb0-d32ba0b79191', 'DELETE', '/api/Categories/Delete', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('5fcabe86-82da-41eb-9004-27577145bcff', 'DELETE', '/api/Images/Delete', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('abc9bb6a-b09f-47a1-89ec-efef70041b28', 'DELETE', '/api/Texts/Delete', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('9aafed68-2ff5-40a6-8a24-7f82f8301ae4', 'PUT', '/api/Products/SoftDeleteProductsWithImages', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('d4a7e1da-ad77-4bbe-8535-a9ed0157a2ef', 'POST', '/api/Products/CreateProductsWithImages', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('5ef5b257-a462-4352-b9c3-2c37b0bb6c59', 'GET', '/api/Brands/Get', '4be33d09-8b6a-427f-ac87-38bc752f4d9a', NULL);


--
-- TOC entry 3361 (class 0 OID 16574)
-- Dependencies: 215
-- Data for Name: Microservices; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Microservices" ("Id", "Name", "FechaBaja") VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6', 'Jwt', NULL);
INSERT INTO public."Microservices" ("Id", "Name", "FechaBaja") VALUES ('4be33d09-8b6a-427f-ac87-38bc752f4d9a', 'ProductsMs', NULL);


--
-- TOC entry 3365 (class 0 OID 16641)
-- Dependencies: 219
-- Data for Name: RoleMethod; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('19565a4d-9516-4ec5-b911-724a2f181bd8', '3fa85f64-5717-4562-b3fc-2c963f66afa6');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('3e17df33-587a-467b-a777-3936d18ee115', '3fa85f64-5717-4562-b3fc-2c963f66afa6');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('41058866-8a02-4ff4-91c9-c1c5c8bf9065', '3fa85f64-5717-4562-b3fc-2c963f66afa6');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('66db3ba3-009d-4db0-99b7-53b0dda49dfa', '3fa85f64-5717-4562-b3fc-2c963f66afa6');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('6f29b00c-5fe4-4952-9d03-a1d5b8d3ac86', '3fa85f64-5717-4562-b3fc-2c963f66afa6');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('80dea577-c5fe-4195-9676-62eb04a48bcc', '3fa85f64-5717-4562-b3fc-2c963f66afa6');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('959edc45-0522-4e89-a6ed-b88829bdd706', '3fa85f64-5717-4562-b3fc-2c963f66afa6');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('6f29b00c-5fe4-4952-9d03-a1d5b8d3ac86', 'e25c0146-9648-4b78-b8ec-813ebd24a5ee');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('0fc154d8-e741-4855-af56-50eb5086751d', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('3c0ae841-9b8a-429d-9a8e-947925a85f9c', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('441ffe07-78ea-4498-9898-e903fb3e638d', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('4e9eb2b1-6051-4f0b-a742-7fc22cb4b15c', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('51a0817b-0c51-4c2c-aafe-006c6ed60b4a', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('5a44fa44-98bd-4c77-9566-7d89e339cbb4', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('5fcabe86-82da-41eb-9004-27577145bcff', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('7125f39b-77b2-41bf-8b72-c81217b7ec70', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('865c4b3e-43ca-4330-850d-b6337e387b29', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('94eefd07-2cdf-47ff-8d52-1834e09fcc31', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('9aafed68-2ff5-40a6-8a24-7f82f8301ae4', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('a11361cd-419b-4149-b8c8-0645ced23172', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('abc9bb6a-b09f-47a1-89ec-efef70041b28', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('b1aa7dba-2115-4299-a721-c0be68600a11', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('c30a1c25-b3af-44a5-a472-dcd3279501e3', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('c730fad7-65bd-40ae-b1e8-2607950876bc', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('d4a7e1da-ad77-4bbe-8535-a9ed0157a2ef', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('d96dba75-22b3-4543-acb0-d32ba0b79191', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('ddd574ac-91d7-4ba1-b925-51383f5de53e', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('e9373509-425b-469a-82eb-7291cf64e382', '923586fa-21e1-419e-9414-b06998b0ba15');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('fbee7bca-beb1-4e51-87d5-70da8e549cea', '923586fa-21e1-419e-9414-b06998b0ba15');


--
-- TOC entry 3362 (class 0 OID 16581)
-- Dependencies: 216
-- Data for Name: Roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Roles" ("Id", "Name", "FechaBaja") VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6', 'AdminJwt', NULL);
INSERT INTO public."Roles" ("Id", "Name", "FechaBaja") VALUES ('e25c0146-9648-4b78-b8ec-813ebd24a5ee', 'JwtUser', NULL);
INSERT INTO public."Roles" ("Id", "Name", "FechaBaja") VALUES ('923586fa-21e1-419e-9414-b06998b0ba15', 'AdminProductMs', NULL);


--
-- TOC entry 3366 (class 0 OID 16656)
-- Dependencies: 220
-- Data for Name: UserRole; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."UserRole" ("RoleId", "UserId") VALUES ('3fa85f64-5717-4562-b3fc-2c963f66afa6', '681c4f4f-fff1-4d00-af0f-8154d9065594');
INSERT INTO public."UserRole" ("RoleId", "UserId") VALUES ('e25c0146-9648-4b78-b8ec-813ebd24a5ee', '291e6f4f-9dd9-491b-a3f9-e8f48692513a');
INSERT INTO public."UserRole" ("RoleId", "UserId") VALUES ('923586fa-21e1-419e-9414-b06998b0ba15', '681c4f4f-fff1-4d00-af0f-8154d9065594');


--
-- TOC entry 3363 (class 0 OID 16588)
-- Dependencies: 217
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Users" ("Id", "Username", "Password", "Name", "Surname", "FechaBaja") VALUES ('681c4f4f-fff1-4d00-af0f-8154d9065594', 'josean', 'admin', 'josean', 'vilchez', NULL);
INSERT INTO public."Users" ("Id", "Username", "Password", "Name", "Surname", "FechaBaja") VALUES ('291e6f4f-9dd9-491b-a3f9-e8f48692513a', 'user', '1234', 'Pepito', 'Perez', NULL);


--
-- TOC entry 3360 (class 0 OID 16569)
-- Dependencies: 214
-- Data for Name: __EFMigrationsHistory; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231027180641_Username', '7.0.13');
INSERT INTO public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") VALUES ('20231029110320_manytomany', '7.0.13');


--
-- TOC entry 3206 (class 2606 OID 16601)
-- Name: Methods PK_Methods; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Methods"
    ADD CONSTRAINT "PK_Methods" PRIMARY KEY ("Id");


--
-- TOC entry 3199 (class 2606 OID 16580)
-- Name: Microservices PK_Microservices; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Microservices"
    ADD CONSTRAINT "PK_Microservices" PRIMARY KEY ("Id");


--
-- TOC entry 3209 (class 2606 OID 16645)
-- Name: RoleMethod PK_RoleMethod; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMethod"
    ADD CONSTRAINT "PK_RoleMethod" PRIMARY KEY ("MethodId", "RoleId");


--
-- TOC entry 3201 (class 2606 OID 16587)
-- Name: Roles PK_Roles; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Roles"
    ADD CONSTRAINT "PK_Roles" PRIMARY KEY ("Id");


--
-- TOC entry 3212 (class 2606 OID 16660)
-- Name: UserRole PK_UserRole; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserRole"
    ADD CONSTRAINT "PK_UserRole" PRIMARY KEY ("RoleId", "UserId");


--
-- TOC entry 3203 (class 2606 OID 16594)
-- Name: Users PK_Users; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Users"
    ADD CONSTRAINT "PK_Users" PRIMARY KEY ("Id");


--
-- TOC entry 3197 (class 2606 OID 16573)
-- Name: __EFMigrationsHistory PK___EFMigrationsHistory; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");


--
-- TOC entry 3204 (class 1259 OID 16637)
-- Name: IX_Methods_IdMicroservice; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_Methods_IdMicroservice" ON public."Methods" USING btree ("IdMicroservice");


--
-- TOC entry 3207 (class 1259 OID 16671)
-- Name: IX_RoleMethod_RoleId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_RoleMethod_RoleId" ON public."RoleMethod" USING btree ("RoleId");


--
-- TOC entry 3210 (class 1259 OID 16672)
-- Name: IX_UserRole_UserId; Type: INDEX; Schema: public; Owner: postgres
--

CREATE INDEX "IX_UserRole_UserId" ON public."UserRole" USING btree ("UserId");


--
-- TOC entry 3213 (class 2606 OID 16602)
-- Name: Methods FK_Methods_Microservices_IdMicroservice; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."Methods"
    ADD CONSTRAINT "FK_Methods_Microservices_IdMicroservice" FOREIGN KEY ("IdMicroservice") REFERENCES public."Microservices"("Id") ON DELETE CASCADE;


--
-- TOC entry 3214 (class 2606 OID 16646)
-- Name: RoleMethod FK_RoleMethod_Methods_MethodId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMethod"
    ADD CONSTRAINT "FK_RoleMethod_Methods_MethodId" FOREIGN KEY ("MethodId") REFERENCES public."Methods"("Id") ON DELETE CASCADE;


--
-- TOC entry 3215 (class 2606 OID 16651)
-- Name: RoleMethod FK_RoleMethod_Roles_RoleId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."RoleMethod"
    ADD CONSTRAINT "FK_RoleMethod_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."Roles"("Id") ON DELETE CASCADE;


--
-- TOC entry 3216 (class 2606 OID 16661)
-- Name: UserRole FK_UserRole_Roles_RoleId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserRole"
    ADD CONSTRAINT "FK_UserRole_Roles_RoleId" FOREIGN KEY ("RoleId") REFERENCES public."Roles"("Id") ON DELETE CASCADE;


--
-- TOC entry 3217 (class 2606 OID 16666)
-- Name: UserRole FK_UserRole_Users_UserId; Type: FK CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."UserRole"
    ADD CONSTRAINT "FK_UserRole_Users_UserId" FOREIGN KEY ("UserId") REFERENCES public."Users"("Id") ON DELETE CASCADE;


-- Completed on 2024-01-19 10:55:51

--
-- PostgreSQL database dump complete
--

