--
-- PostgreSQL database dump
--

-- Dumped from database version 15.2
-- Dumped by pg_dump version 15.2

-- Started on 2023-05-06 14:26:55

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
-- TOC entry 219 (class 1259 OID 16459)
-- Name: user; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public."user" (
    id integer NOT NULL,
    login character varying,
    password character varying,
    created_date date,
    user_group_id integer,
    user_state_id integer
);


ALTER TABLE public."user" OWNER TO postgres;

--
-- TOC entry 217 (class 1259 OID 16451)
-- Name: user_group; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_group (
    id integer NOT NULL,
    code character varying,
    description character varying
);


ALTER TABLE public.user_group OWNER TO postgres;

--
-- TOC entry 216 (class 1259 OID 16450)
-- Name: user_group_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.user_group ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.user_group_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 218 (class 1259 OID 16458)
-- Name: user_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public."user" ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.user_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 215 (class 1259 OID 16443)
-- Name: user_state; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.user_state (
    id integer NOT NULL,
    code character varying,
    description character varying
);


ALTER TABLE public.user_state OWNER TO postgres;

--
-- TOC entry 214 (class 1259 OID 16442)
-- Name: user_state_id_seq; Type: SEQUENCE; Schema: public; Owner: postgres
--

ALTER TABLE public.user_state ALTER COLUMN id ADD GENERATED ALWAYS AS IDENTITY (
    SEQUENCE NAME public.user_state_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);


--
-- TOC entry 3336 (class 0 OID 16459)
-- Dependencies: 219
-- Data for Name: user; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public."user" (id, login, password, created_date, user_group_id, user_state_id) FROM stdin;
1	test	test	2023-05-06	1	2
13	ee	ee	2023-05-06	2	2
3	qwerty	1234	2021-04-02	2	2
16	ertergre	dfgre	2023-05-06	2	1
17	sdfsdfs	sfsdfsdfs	2023-05-06	2	2
\.


--
-- TOC entry 3334 (class 0 OID 16451)
-- Dependencies: 217
-- Data for Name: user_group; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.user_group (id, code, description) FROM stdin;
1	Admin	\N
2	User	\N
\.


--
-- TOC entry 3332 (class 0 OID 16443)
-- Dependencies: 215
-- Data for Name: user_state; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.user_state (id, code, description) FROM stdin;
1	Active	\N
2	Blocked	\N
\.


--
-- TOC entry 3342 (class 0 OID 0)
-- Dependencies: 216
-- Name: user_group_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_group_id_seq', 2, true);


--
-- TOC entry 3343 (class 0 OID 0)
-- Dependencies: 218
-- Name: user_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_id_seq', 18, true);


--
-- TOC entry 3344 (class 0 OID 0)
-- Dependencies: 214
-- Name: user_state_id_seq; Type: SEQUENCE SET; Schema: public; Owner: postgres
--

SELECT pg_catalog.setval('public.user_state_id_seq', 2, true);


--
-- TOC entry 3186 (class 2606 OID 16457)
-- Name: user_group user_group_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_group
    ADD CONSTRAINT user_group_pkey PRIMARY KEY (id);


--
-- TOC entry 3188 (class 2606 OID 16465)
-- Name: user user_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public."user"
    ADD CONSTRAINT user_pkey PRIMARY KEY (id);


--
-- TOC entry 3184 (class 2606 OID 16447)
-- Name: user_state user_state_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.user_state
    ADD CONSTRAINT user_state_pkey PRIMARY KEY (id);


-- Completed on 2023-05-06 14:26:55

--
-- PostgreSQL database dump complete
--

