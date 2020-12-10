CREATE SCHEMA retail;

CREATE TABLE retail.address
(
    id integer NOT NULL,
    line1 character varying(255) COLLATE pg_catalog."default" NOT NULL,
    line2 character varying(255) COLLATE pg_catalog."default",
    postal_code character varying(6) COLLATE pg_catalog."default" NOT NULL,
    state character varying(16) COLLATE pg_catalog."default" NOT NULL,
    country character varying(16) COLLATE pg_catalog."default" NOT NULL,
    CONSTRAINT pk_address_id PRIMARY KEY (id)
)

TABLESPACE pg_default;


CREATE TABLE retail."order"
(
    id integer NOT NULL,
    address_id integer NOT NULL,
    order_status integer,
    created_time timestamp(6) without time zone NOT NULL,
    updated_time timestamp(6) without time zone,
    CONSTRAINT pk_order_id PRIMARY KEY (id),
    CONSTRAINT fk_order_address_id_address_id FOREIGN KEY (address_id)
        REFERENCES retail.address (id) MATCH SIMPLE
        ON UPDATE NO ACTION
        ON DELETE NO ACTION
        NOT VALID
)

TABLESPACE pg_default;


CREATE TABLE retail.product
(
    id integer NOT NULL,
    name character varying(255) COLLATE pg_catalog."default" NOT NULL,
    description character varying(255) COLLATE pg_catalog."default" NOT NULL,
    quantity integer NOT NULL,
    price integer,
    CONSTRAINT pk_product_id PRIMARY KEY (id)
)

TABLESPACE pg_default;

CREATE TABLE retail.orderproduct
(
    order_id integer NOT NULL,
    product_id integer NOT NULL,
    CONSTRAINT pk_orderproduct_order_id_product_id PRIMARY KEY (order_id, product_id)
)

TABLESPACE pg_default;
