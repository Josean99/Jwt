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
-- TOC entry 3361 (class 0 OID 16574)
-- Dependencies: 215
-- Data for Name: Microservices; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Microservices" ("Id", "Name", "FechaBaja") VALUES ('1547d41e-59e2-4f4c-ace8-21c83181a162', 'Jwt', NULL);


--
-- TOC entry 3364 (class 0 OID 16595)
-- Dependencies: 218
-- Data for Name: Methods; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('0f3342b9-0578-4ffc-8990-3d8ae30952b0', 'POST', '/api/Signup', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('3156fb8d-37c4-4772-ac8c-03934505b879', 'POST', '/api/Login/GetAllowedMethods', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('43f1da9b-1b85-498b-b189-d18367968369', 'GET', '/api/Method/GetByRole', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('49a2b842-5d4d-4ea3-974c-d19a7d0420cd', 'POST', '/api/Method/Post', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('49b94ac7-c6f7-4573-8e7b-4e701091358c', 'GET', '/api/Microservice/GetAll', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('7904de77-ff78-4697-903f-d51e2891e52e', 'POST', '/api/Login/Post', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('83029f4a-6f2a-4f22-a93b-30569e22a579', 'GET', '/api/Login/Enviroment', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('aca22726-eb8f-44e3-88c8-5fec44f70d04', 'POST', '/api/Role/Post', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('acdbd0de-3f5c-406f-a9cc-911ad0658fb9', 'GET', '/api/Method/GetByMicroservice', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('d6d08a83-3e88-4d4b-9c97-b023475e0ef9', 'POST', '/api/Microservice/Post', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('e299bdc8-3e1e-4152-9601-83fa4852558f', 'POST', '/api/Signup/AssociateRole/{idUser}', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('cdbc709b-2466-4e72-947a-ce9b5385ddeb', 'DELETE', '/api/Microservice/SoftDelete', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('7053551f-6d66-4682-8575-42f1affa0344', 'PUT', '/api/Microservice/Put', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('1facd9e6-8b67-408c-8abe-fdd2fbfbfdad', 'DELETE', '/api/Role/SoftDelete', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('6890954e-3eee-4ed6-a654-027ad6339b51', 'PUT', '/api/Role/Put', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);
INSERT INTO public."Methods" ("Id", "Verb", "Path", "IdMicroservice", "FechaBaja") VALUES ('1dd58b6b-7482-4b5d-a4b2-43db564476fd', 'GET', '/api/Role/GetAll', '1547d41e-59e2-4f4c-ace8-21c83181a162', NULL);


--
-- TOC entry 3362 (class 0 OID 16581)
-- Dependencies: 216
-- Data for Name: Roles; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Roles" ("Id", "Name", "FechaBaja") VALUES ('4eff5b74-b6d7-4384-9a6d-22985cf0ad8a', 'JwtMSAdmin', NULL);


--
-- TOC entry 3365 (class 0 OID 16641)
-- Dependencies: 219
-- Data for Name: RoleMethod; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('0f3342b9-0578-4ffc-8990-3d8ae30952b0', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('3156fb8d-37c4-4772-ac8c-03934505b879', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('43f1da9b-1b85-498b-b189-d18367968369', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('49a2b842-5d4d-4ea3-974c-d19a7d0420cd', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('49b94ac7-c6f7-4573-8e7b-4e701091358c', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('7904de77-ff78-4697-903f-d51e2891e52e', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('83029f4a-6f2a-4f22-a93b-30569e22a579', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('aca22726-eb8f-44e3-88c8-5fec44f70d04', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('acdbd0de-3f5c-406f-a9cc-911ad0658fb9', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('d6d08a83-3e88-4d4b-9c97-b023475e0ef9', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('e299bdc8-3e1e-4152-9601-83fa4852558f', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('cdbc709b-2466-4e72-947a-ce9b5385ddeb', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('7053551f-6d66-4682-8575-42f1affa0344', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('1facd9e6-8b67-408c-8abe-fdd2fbfbfdad', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('6890954e-3eee-4ed6-a654-027ad6339b51', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');
INSERT INTO public."RoleMethod" ("MethodId", "RoleId") VALUES ('1dd58b6b-7482-4b5d-a4b2-43db564476fd', '4eff5b74-b6d7-4384-9a6d-22985cf0ad8a');


--
-- TOC entry 3363 (class 0 OID 16588)
-- Dependencies: 217
-- Data for Name: Users; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."Users" ("Id", "Username", "Password", "Name", "Surname", "FechaBaja") VALUES ('8851442f-3048-4dd7-bc44-5f0d2b2853a3', 'desarrollo', 'desarrollo', 'desarrollo', 'desarrollo', NULL);
INSERT INTO public."Users" ("Id", "Username", "Password", "Name", "Surname", "FechaBaja") VALUES ('681c4f4f-fff1-4d00-af0f-8154d9065594', 'josean', 'admin', 'josean', 'vilchez', NULL);


--
-- TOC entry 3366 (class 0 OID 16656)
-- Dependencies: 220
-- Data for Name: UserRole; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public."UserRole" ("RoleId", "UserId") VALUES ('4eff5b74-b6d7-4384-9a6d-22985cf0ad8a', '681c4f4f-fff1-4d00-af0f-8154d9065594');


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

